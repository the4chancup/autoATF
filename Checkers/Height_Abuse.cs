using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    class Height_Abuse
    {
        private struct brackets
        {
            public uint bracket_1;
            public uint bracket_2;
            public uint bracket_3;
            public uint bracket_4;
            public uint bracket_5;
            public uint bracket_6;
            public uint bracket_7;
            public uint bracket_8;

            public int height_total;
        }
        
        public static void check_height_abuse(team squad)
        {
            brackets heights;

            heights.bracket_1 = 0;
            heights.bracket_2 = 0;
            heights.bracket_3 = 0;
            heights.bracket_4 = 0;
            heights.bracket_5 = 0;
            heights.bracket_6 = 0;
            heights.bracket_7 = 0;
            heights.bracket_8 = 0;
            heights.height_total = 0;

            uint system1_stats = 0;
            int system_type = 0; // 0 = unknown, 1 = system1, 2 = system2

            // Check heights of all players in team
            foreach (player line in squad.team_players)
            {
                // Add height to running total for team
                // SEC16 - Players below 175cm will be counted as 175 for squad totals
                if ((line.height < constants.height_bracket_6) && (line.height >= constants.height_bracket_7))
                {
                    heights.height_total += (int)constants.height_bracket_6;
                }
                else
                {
                    heights.height_total += line.height;
                }

                // Check for any System1 Stats Players
                if(line.is_gold_system1 == true || line.is_silver_system1 == true || line.is_regular_system1 == true || line.is_goalkeeper_system1 == true)
                {
                    system1_stats++;
                }

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
                else if (line.height >= constants.height_bracket_1)
                {
                    heights.bracket_1++;
                }
                else if (line.height >= constants.height_bracket_2)
                {
                    heights.bracket_2++;
                }
                else if (line.height >= constants.height_bracket_3)
                {
                    heights.bracket_3++;
                }
                else if (line.height >= constants.height_bracket_4)
                {
                    heights.bracket_4++;
                }
                else if (line.height >= constants.height_bracket_5)
                {
                    heights.bracket_5++;
                }
                else if (line.height >= constants.height_bracket_7)
                {
                    heights.bracket_6++;
                }
/* -- SEC16 - These brackets have been collapsed into bracket 6
                else if (line.height >= constants.height_bracket_7)
                {
                    heights.bracket_7++;
                }
                else if (line.height >= constants.height_bracket_8)
                {
                    heights.bracket_8++;
                }
*/
                else if (line.height >= constants.height_minimum_pes)
                {
                    Console.WriteLine("MANLET ABUSE:\n" + line.id + "\t" + line.name + " has a height below the 4cc limit of " + constants.height_bracket_7);
                    variables.errors++;
                }
                else
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has an invalid height and may crash the game\nYou must have seriously fucked up your export to trigger this");
                    variables.errors++;
                }
            }

            // For Brackets 1-4 there are two systems - System1 and System2
            // System1 is the original system, but all players above 189cm take a variable stat nerf depending on their medal (-5 for Golds, -4 for Silvers, -3 for Regulars and GKs)
            // System2 has no players above 189cm, and shifts those four players to the 185-189cm bracket for no stat nerf

            // Firstly, we need to determine what System the manager intended
            // To do this, first we check if any players have a stat nerf
            // If any players have this nerf, we can assume the manager intended to use System 1, because what are the chances they intended to use System2 but accidentally gave a player a perfect stats nerf for their medal?
            if(system1_stats > 0)
            {
                Console.WriteLine("Assuming Height Abuse System 1 (all players above 189cm have a variable stats nerf)\n");
                system_type = 1;

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

            // If no players have the System1 Stats, it could still be System1 but the manager hasn't applied the stats nerf
            // We need to look at the brackets to be sure
            else
            {
                // Count up the number of 190cm+ players
                uint sixfootmasterrace = heights.bracket_1 + heights.bracket_2 + heights.bracket_3;

                if (sixfootmasterrace == 0)
                {
                    // If there are no 190cm+ players, assume System2
                    Console.WriteLine("Assuming Height Abuse System 2 (no players taller than 189cm)\n");
                    system_type = 2;
                }

                else if (sixfootmasterrace < 4)
                {
                    // This is sort of a grey area, it could be a System1 with too few giants, or a System2 with too many
                    // Considering there are no stats nerfs, and too few giants, its closer to System2 so lets go with that
                    Console.WriteLine("Assuming Height Abuse System 2 (no players taller than 189cm)\n");
                    system_type = 2;
                }

                else if (sixfootmasterrace == 4)
                {
                    // No stats nerfs but a perfect 4 players above 189cm, so assume System1
                    Console.WriteLine("Assuming Height Abuse System 1 (all players above 189cm have a variable stats nerf)\n");
                    system_type = 1;
                }

                else // (sixfootmasterrace > 4)
                {
                    // Nice try /wg/, but that's illegal even in System1, which we're going to assume you're using
                    // This is not the time for errors, that comes later
                    Console.WriteLine("Assuming Height Abuse System 1 (all players above 189cm have a variable stats nerf)\n");
                    system_type = 1;
                }
            }

            // So now we have some idea of what system is being used
            // It might be wrong though! But if it is then there are multiple things wrong with the save which the following checks should weed out
            if(system_type == 1)
            {
                // System1 Type Checks
                // Check for too many players in a height bracket
                if (heights.bracket_1 > constants.system1_height_bracket_1_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_1 + "-" + constants.height_maximum_4cc + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_1 + " out of " + constants.system1_height_bracket_1_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_2 > constants.system1_height_bracket_2_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_2 + "-" + (constants.height_bracket_1 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_2 + " out of " + constants.system1_height_bracket_2_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_3 > constants.system1_height_bracket_3_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_3 + "-" + (constants.height_bracket_2 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_3 + " out of " + constants.system1_height_bracket_3_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_4 > constants.system1_height_bracket_4_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_4 + "-" + (constants.height_bracket_3 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_4 + " out of " + constants.system1_height_bracket_4_limit + ")");
                    variables.errors++;
                }

                // Check for too few players in a height bracket
                if (heights.bracket_1 < constants.system1_height_bracket_1_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_1 + "-" + constants.height_maximum_4cc + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_1 + " out of " + constants.system1_height_bracket_1_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_2 < constants.system1_height_bracket_2_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_2 + "-" + (constants.height_bracket_1 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_2 + " out of " + constants.system1_height_bracket_2_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_3 < constants.system1_height_bracket_3_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_3 + "-" + (constants.height_bracket_2 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_3 + " out of " + constants.system1_height_bracket_3_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_4 < constants.system1_height_bracket_4_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_4 + "-" + (constants.height_bracket_3 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_4 + " out of " + constants.system1_height_bracket_4_limit + ")");
                    variables.errors++;
                }

                // Check total team height
                if (heights.height_total > constants.system1_height_limit_total)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has broken the total height limit of " + constants.system1_height_limit_total);
                    Console.WriteLine("\t\t (Has " + heights.height_total + " out of " + constants.system1_height_limit_total + ")");
                    variables.errors++;
                }

                // Check if all 190cm+ players have the variable stats nerf
                foreach (player line in squad.team_players)
                {
                    if(line.height >= 190)
                    {
                        if (line.is_gold_system1 == false && line.is_silver_system1 == false && line.is_regular_system1 == false && line.is_goalkeeper_system1 == false)
                        {
                            Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has not correctly nerfed " + line.name);
                            Console.WriteLine("\t\t (Is " + line.height + "cm but does not have an appropriate stats nerf)");
                            variables.errors++;
                        }
                    }
                }
            }
            else if (system_type == 2)
            {
                // System2 Type Checks
                // Check for too many players in a height bracket
                if (heights.bracket_1 > constants.system2_height_bracket_1_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_1 + "-" + constants.height_maximum_4cc + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_1 + " out of " + constants.system2_height_bracket_1_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_2 > constants.system2_height_bracket_2_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_2 + "-" + (constants.height_bracket_1 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_2 + " out of " + constants.system2_height_bracket_2_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_3 > constants.system2_height_bracket_3_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_3 + "-" + (constants.height_bracket_2 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_3 + " out of " + constants.system2_height_bracket_3_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_4 > constants.system2_height_bracket_4_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_4 + "-" + (constants.height_bracket_3 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_4 + " out of " + constants.system2_height_bracket_4_limit + ")");
                    variables.errors++;
                }

                // Check for too few players in a height bracket
                if (heights.bracket_1 < constants.system2_height_bracket_1_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_1 + "-" + constants.height_maximum_4cc + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_1 + " out of " + constants.system2_height_bracket_1_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_2 < constants.system2_height_bracket_2_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_2 + "-" + (constants.height_bracket_1 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_2 + " out of " + constants.system2_height_bracket_2_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_3 < constants.system2_height_bracket_3_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_3 + "-" + (constants.height_bracket_2 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_3 + " out of " + constants.system2_height_bracket_3_limit + ")");
                    variables.errors++;
                }

                if (heights.bracket_4 < constants.system2_height_bracket_4_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_4 + "-" + (constants.height_bracket_3 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + heights.bracket_4 + " out of " + constants.system2_height_bracket_4_limit + ")");
                    variables.errors++;
                }

                // Check total team height
                if (heights.height_total > constants.system2_height_limit_total)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has broken the total height limit of " + constants.system2_height_limit_total);
                    Console.WriteLine("\t\t (Has " + heights.height_total + " out of " + constants.system2_height_limit_total + ")");
                    variables.errors++;
                }
            }

            else
            {
                // This should never trigger
                Console.WriteLine("HEIGHT ABUSE:\n" + "Cannot determine the Height Abuse System used by " + squad.team_name);
                Console.WriteLine("This should never trigger, so if it has, this team is properly fucked");
                variables.errors++;
            }

            // Regardless of what height abuse system is used, 184 and below is the same
            if (heights.bracket_5 < constants.height_bracket_5_limit)
            {
                Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_5 + "-" + (constants.height_bracket_4 - 1) + " bracket");
                Console.WriteLine("\t\t (Has " + heights.bracket_5 + " out of " + constants.height_bracket_5_limit + ")");
                variables.errors++;
            }

            if (heights.bracket_6 < constants.height_bracket_6_limit)
            {
                Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_7 + "-" + (constants.height_bracket_5 - 1) + " bracket");
                Console.WriteLine("\t\t (Has " + heights.bracket_6 + " out of " + constants.height_bracket_6_limit + ")");
                variables.errors++;
            }
/* -- SEC16 - These brackets have been collapsed into bracket 6
            if (heights.bracket_7 < constants.height_bracket_7_limit)
            {
                Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_7 + "-" + (constants.height_bracket_6 - 1) + " bracket");
                Console.WriteLine("\t\t (Has " + heights.bracket_7 + " out of " + constants.height_bracket_7_limit + ")");
                variables.errors++;
            }

            if (heights.bracket_8 < constants.height_bracket_8_limit)
            {
                Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_8 + "-" + (constants.height_bracket_7 - 1) + " bracket");
                Console.WriteLine("\t\t (Has " + heights.bracket_8 + " out of " + constants.height_bracket_8_limit + ")");
                variables.errors++;
            }
*/
        }
    }
}
