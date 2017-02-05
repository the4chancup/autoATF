using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace AATF
{
    public class checker
    {
        public static void team_input(team squad)
        {
            while (true)
            {
                // Input team to be checked
                Console.WriteLine("Enter team name:\t(Without slashes)");
                string team_being_checked = "/" + Console.ReadLine() + "/";
                Console.WriteLine();

                // Lookup what teamID this corresponds to
                Hashtable teams_4cc = new Hashtable();
                teams_4cc = Lookup.setup_teams_4cc();

                if (!teams_4cc.ContainsValue(team_being_checked))
                {
                    Console.WriteLine("Invalid 4cc Team");
                }
                else
                {
                    string Key = "";
                    IDictionaryEnumerator e = teams_4cc.GetEnumerator();
                    while (e.MoveNext())
                    {
                        if (e.Value.ToString().Equals(team_being_checked))
                        {
                            Key = e.Key.ToString();
                        }
                    }

                    squad.team_name = team_being_checked;
                    squad.teamID = Convert.ToInt32(Key);
                    break;
                }
            }
        }

        public static void check_em(team squad)
        {
            // If you've triggered an error already, just stop
            if (variables.errors == 0)
            {
                // Player-specific checks

                // Loop through every player in the player table
                foreach (player line in squad.team_players)
                {
                    Console.WriteLine("* Checking " + line.name);

                    // Check Stats and set Gold/Silver/Regular/Goalkeeper marker
                    // This MUST be done first, as subsequent checks may need to use the markers
                    // NOTE: If a player fails this, they will not have a type marker set and so will fall through type checks
                    Check_Stats.check_stats(line);

                    // Check Attacking/Defensive Prowess
                    Check_Stats.check_prowess(line);

                    // Check Form against the player type
                    Check_Form.check_form(line);

                    // Check if manlets have correctly augmented weakfoot stats
                    // Check all other player have correct weakfoot stats
                    Check_Weakfoot.check_manlet_weakfoot(line);

                    // Check if players have the correct proficiency in their registered position
                    // Check that this is the only position they have proficiency in
                    Check_Position.check_player_positions(line);

                    // Check if players have the correct Injury Tolerance
                    Check_InjuryTolerance.check_injurytolerance(line);

                    // Check if players have the right number of cards for their type
                    // Verify there is only one Captain
                    Check_Cards.check_cards(line, squad);

                    // Check other miscellaneous abuses
                    Check_Basics.check_basics(line);
                }

                // Team-wide checks

                // Check GGSS allocation
                Check_Stats.check_ggss(squad);

                // Check the position allocations
                Check_Position.check_team_positions(squad);

                // Check Height Abuse
                Height_Abuse.check_height_abuse(squad);

                // Check Captaincy
                Check_Cards.check_captaincy(squad);
                
                // Checking finished
                // Are there any errors?
                Console.WriteLine();

                // Print the number of errors that were detected for that team
                Console.WriteLine("Errors: " + variables.errors);

                // #bantz
                if (variables.errors != 0)
                {
                    if (squad.team_name.Equals("/mlp/"))
                    {
                        Console.WriteLine("HORSEFUCKERS OUT");
                    }
                    else if (squad.team_name.Equals("/k/"))
                    {
                        Console.WriteLine(pasta.navyseals);
                    }
                    else if (squad.team_name.Equals("/tv/"))
                    {
                        Console.WriteLine("Well congratulations, you got yourself rigged! Now what's the next step of you master plan?");
                    }
                    else
                    {
                        Console.WriteLine(squad.team_name + " manager should kill themselves");
                    }
                }
                else
                {
                    Console.WriteLine("Perfect, Blaze!");
                }

                // Check Complete
                Console.WriteLine();
                Console.WriteLine("Team check complete!");
                Console.WriteLine();
            }
        }

        public static void teambuilding(List<player> player_table, team squad)
        {
            foreach (player line in player_table)
            {
                if (line.Team_id == squad.teamID)
                {
                    // Add player to the squad
                    squad.team_players.Add(line);

                    // DEBUG - list of player names
                    squad.team_names.Add(line.name);
                }
            }
        }

        public static void check_squad_consistency(team squad)
        {
            foreach (player line in squad.team_players)
            {
                if (line.Team_id != squad.teamID)
                {
                    // That player is not meant to be on that team!
                    // Someone has either fucked up their export, been transferring players around
                    // Either way, that's an error
                    Console.WriteLine(line.id + "\t" + line.name + "\nshould not be on this team!");
                    Console.WriteLine("\t\t(Belongs to " + line.Team_name + ")");
                    variables.errors++;
                }
            }
        }
    }
}
