using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    class Height_Abuse
    {
        public static void check_height_abuse(team squad)
        {
            uint[] brackets = new uint[constants.height_brackets.Length];
            uint height_total = 0;

            uint system1_stats = 0;

            List<player> multipos = new List<player>();

            // Check heights of all players in team
            foreach (player line in squad.team_players)
            {
                // Add height to running total for team
                // SEC16 - Players below 175cm will be counted as 175 for squad totals
                if ((line.height < constants.height_brackets[5]) && (line.height >= constants.height_brackets[6]))
                {
                    height_total += (uint)constants.height_brackets[5];
                }
                else
                {
                    height_total += (uint)line.height;
                }

                // Check for any System1 Stats Players
                if (line.statType == 1)
                {
                    system1_stats++;
                }

                // Check for any System2 multipos players
                if (line.is_multipos_system2) { multipos.Add(line); }

                // Check height against bracket boundaries, increment number of players in the bracket
                if (line.height > constants.height_maximum_pes)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + line.id + "\t" + line.name + " has a height of " + line.height + ", which is above the PES limit of " + constants.height_maximum_pes + "\nThis will probably crash the game. Good job.");
                    variables.errors++;
                }
                else if (line.height > constants.height_maximum_4cc)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + line.id + "\t" + line.name + " has a height above the 4cc limit of " + constants.height_maximum_4cc);
                    variables.errors++;
                }

                bool check = false;
                // iterate across standard brackets
                for (uint i = 0; i < constants.height_brackets.Length; ++i)
                {
                    if (line.height >= constants.height_brackets[i])
                    {
                        line.height_bracket = i;
                        brackets[i] += 1;
                        check = true;
                        break;
                    }
                }
                // special failure cases
                if (!check)
                {
                    if (line.height >= constants.height_minimum_pes)
                    {
                        Console.WriteLine("MANLET ABUSE:\n" + line.id + "\t" + line.name + " has a height below the 4cc limit of " + constants.height_brackets[constants.height_brackets.Length-1]);
                        variables.errors++;
                    }
                    else
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " has an invalid height and may crash the game\nYou must have seriously fucked up your export to trigger this");
                        variables.errors++;
                    }
                }
            }

            // For Brackets 1-4 there are two systems - System1 and System2
            // System1 is the original system, but all players above 189cm take a variable stat nerf depending on their medal (-5 for Golds, -4 for Silvers, -3 for Regulars and GKs)
            // System2 has no players above 189cm, and shifts those four players to the 185-189cm bracket for no stat nerf

            // Firstly, we need to determine what System the manager intended
            // To do this, first we check if any players have a stat nerf
            // If any players have this nerf, we can assume the manager intended to use System 1, because what are the chances they intended to use System2 but accidentally gave a player a perfect stats nerf for their medal?
            heightsystem system = null;
            if (system1_stats > 0)
            {
                system = constants.system1;
                Console.WriteLine("Assuming Height Abuse System " + system.id + " (" + system.desc + ")\n");
                
                // Lets do some error checking while we're here
                if (system1_stats < 4)
                {
                    // Looks like the team doesn't have enough players with the stats nerf
                    // So it could be a mistake with System1 or a badly mangled System2, either way its an error
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players with the variable stats nerf");
                    Console.WriteLine("\t\t (Has " + system1_stats + " should have 4)");
                    variables.errors++;
                }

                else if (system1_stats == 4)
                {
                    // Precisely 4, perfect
                }

                else // (system1_stats > 4)
                {
                    // Good job, you managed to nerf too many players
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players with the variable stats nerf");
                    Console.WriteLine("\t\t (Has " + system1_stats + " should have 4)");
                    variables.errors++;
                }
            }
            // If no players have nerfed stats, check if any players have multiple positions.
            // If any players have been added to the multipos list, assume this is System 2, because they probably wouldn't assign multiple positions.
            else if (multipos.Count > 0)
            {
                system = constants.system2;
                Console.WriteLine("Assuming Height Abuse System " + system.id + " (" + system.desc + ")\n");
            }

            // If no players have the System1 Stats or System2 positions, it could still be System1 but the manager hasn't applied the stats nerf
            // We need to look at the brackets to be sure
            else
            {
                // Count up the number of 190cm+ players
                uint sixfootmasterrace = brackets[0] + brackets[1] + brackets[2];

                // If there are no 190cm+ players, assume System2
                if (sixfootmasterrace == 0) { system = constants.system2; }

                // This is sort of a grey area, it could be a System1 with too few giants, or a System2 with too many
                // Considering there are no stats nerfs, and too few giants, its closer to System2 so lets go with that
                else if (sixfootmasterrace < 4) { system = constants.system2; }

                // No stats nerfs but a perfect 4 players above 189cm, so assume System1
                else if (sixfootmasterrace == 4) { system = constants.system1; }

                // equivalent to (sixfootmasterrace > 4)
                // Nice try /wg/, but that's illegal even in System1, which we're going to assume you're using
                // This is not the time for errors, that comes later
                else { system = constants.system1; }

                Console.WriteLine("Assuming Height Abuse System " + system.id + " (" + system.desc + ")\n");
            }
            
            if (system == null)
            {
                // This should never trigger
                Console.WriteLine("HEIGHT ABUSE:\n" + "Cannot determine the Height Abuse System used by " + squad.team_name);
                Console.WriteLine("This should never trigger, so if it has, this team is properly fucked");
                variables.errors++;
                return;
            }

            // check system limits
            // check total height
            if (height_total > system.total_limit)
            {
                Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " (System " + system.id + ") has total height " + height_total + " but maximum permitted is " + system.total_limit);
                variables.errors++;
            }
            // check players in bracket
            uint prevBracket = constants.height_maximum_4cc;
            for (uint i = 0; i < system.limits.Length; ++i )
            {
                string error = null;
                // check if too many players
                if (brackets[i] > system.limits[i]) { error = "many"; }
                // check if too few players
                else if (brackets[i] < system.limits[i]) { error = "few"; }
                // if either of these is set, give an error
                if (error != null)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too " + error + " players in the " + constants.height_brackets[i] + "-" + prevBracket + " bracket");
                    Console.WriteLine("\t\t (Has " + brackets[i] + " out of " + system.limits[i] + ")");
                    variables.errors++;
                }
                prevBracket = constants.height_brackets[i];
            }
            // Check multi-position players to see if they fall in the right height brackets
            foreach (player line in multipos)
            {
                if (line.height_bracket < system.min_double_a_bracket)
                {
                    string msg = "";
                    if (system.min_double_a_bracket == 999) { msg = "system does not permit multiple positions."; }
                    else { msg = "height above maximum of " + (constants.height_brackets[system.min_double_a_bracket] + 4); }

                    Console.WriteLine("HEIGHT ABUSE:\n" + line.id + "\t" + line.name + " has two positions but "+msg);
                    variables.errors++;
                }
            }
        }
    }
}
