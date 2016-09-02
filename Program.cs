using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF_15
{
    public static class variables
    {
        static uint _errors;

        public static uint errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }
    }

    public static class pasta
    {
        public const string navyseals = "What the fuck did you just fucking say about me, you little bitch? I’ll have you know I graduated top of my class in the Navy Seals, and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You’re fucking dead, kiddo.";
    }

    public static class constants
    {
        public const uint players_per_team = 23;

        public const uint stats_gold = 99;
        public const uint stats_silver = 88;
        public const uint stats_regular = 77;
        public const uint stats_goalkeeper = 80;

        // Summer 2015 Ruleset - All players above 189cm in height get a variable stat nerf
        public const uint stats_gold_system1 = 94;
        public const uint stats_silver_system1 = 84;
        public const uint stats_regular_system1 = 74;
        public const uint stats_goalkeeper_system1 = 77;

        public const uint form_gold = 8;
        public const uint form_silver = 8;
        public const uint form_regular = 4;
        public const uint form_goalkeeper = 4;

        public const uint weakfoot_accuracy = 2;
        public const uint weakfoot_usage = 2;

        public const uint weakfoot_manlet_height = 179;
        public const uint weakfoot_accuracy_manlet = 4;
        public const uint weakfoot_usage_manlet = 4;

        public const uint injury_tolerance = 3;

        public const uint cards_limit_goalkeeper = 1;
        public const uint cards_limit_regular = 2;
        public const uint cards_limit_silver = 3;
        public const uint cards_limit_gold = 4;

        public const uint positions_minimum_gk = 2;
        public const uint positions_minimum_def = 2;
        public const uint positions_minimum_mf = 1;
        public const uint positions_minimum_fw = 1;

        public const uint players_gold = 2;
        public const uint players_silver = 2;
        public const uint players_regular_and_gk = 19;

        public const uint height_maximum_pes = 210;
        public const uint height_maximum_4cc = 205;

        public const uint height_bracket_1 = 200;
        public const uint height_bracket_2 = 195;
        public const uint height_bracket_3 = 190;
        public const uint height_bracket_4 = 185;
        public const uint height_bracket_5 = 180;
        public const uint height_bracket_6 = 175;
        public const uint height_bracket_7 = 155;
//        public const uint height_bracket_8 = 155; // SEC16 - Brackets 7 and 8 have been collapsed into 6
        public const uint height_minimum_pes = 148;

        // Height Abuse
        // System 1
        public const uint system1_height_bracket_1_limit = 1;
        public const uint system1_height_bracket_2_limit = 1;
        public const uint system1_height_bracket_3_limit = 2;
        public const uint system1_height_bracket_4_limit = 6;
        public const uint system1_height_limit_total = 4220;

        // System 2
        public const uint system2_height_bracket_1_limit = 0;
        public const uint system2_height_bracket_2_limit = 0;
        public const uint system2_height_bracket_3_limit = 0;
        public const uint system2_height_bracket_4_limit = 10;
        public const uint system2_height_limit_total = 4185;

        // Both
        public const uint height_bracket_5_limit = 7;
        public const uint height_bracket_6_limit = 6;
        public const uint height_bracket_7_limit = 0;
        public const uint height_bracket_8_limit = 0;

        // Age Abuse
        public const uint age_maximum = 50;
        public const uint age_minimum = 15;        
    }

    public class team
    {
        public string team_name;
        public int teamID;

        public int captains;

        public List<player> team_players = new List<player>();

        // DEBUG - list of player names
        public List<string> team_names = new List<string>();
    }

    class Program
    {
        public static int Count_Bool(params bool[] args)
        {
            return args.Count(t => t);
        }

        static void Main(string[] args)
        {
            variables.errors = 0;

            bool ini_setup = false;

            Console.Title = "autoATF - PES 2016 - Summer 2016 Edition - v0.4";

            // INI setup
            ini_setup = Parser.setup_switches();

            // Only continue if the ini setup was successful, otherwise there will be no input file and the csv parser will fall over
            if (ini_setup)
            {
                // Are we checking, or comparing?
                // The compare_file should be blank if we're checking, and have a file if we're comparing
                if (switches.compare_file == "")
                {
                    // *** Checking ***

                    Console.WriteLine("Entering Checker Mode...\n");

                    // Is it an edit.bin, or a texport.bin?
                    if (Importer.is_edit_bin(switches.input_file))
                    {
                        List<player> player_table = new List<player>();

                        // Parse the edit.bin
                        player_table = Importer.save_importer(switches.input_file);

                        while (true)
                        {
                            team squad = new team();

                            // What team to check?
                            checker.team_input(squad);

                            // Construct that team
                            checker.teambuilding(player_table, squad);

                            // Check that team
                            checker.check_em(squad);

                            // Reset the error count for the next team
                            variables.errors = 0;
                        }
                    }
                    else // Its a texport.bin
                    {
                        team squad = new team();

                        // Parse the texport.bin
                        squad = Importer.export_importer(switches.input_file);

                        Console.WriteLine("Team Export:\t" + squad.team_name);
                        Console.WriteLine();

                        // Check that the players are meant to be on that team
                        checker.check_squad_consistency(squad);

                        // Check that team
                        checker.check_em(squad);
                    }
                }
                else
                {
                    // *** Comparing ***

                    Console.WriteLine("Entering Compare Mode...\n");

                    // What team are we comparing?
                    // If one of the files is an export, we can assume that one

                    int type = -1; // 0 - Save/Save, 1 - Save/Export, 2 - Export/Save, 3 - Export/Export, -1 - ERROR

                    type = comparer.get_compare_type();

                    // So now we know what setup we have, lets start parsing the files
                    switch (type)
                    {
                        case 0: // Save/Save

                            // This is the only type that can loop infinitely, as you can check a different team every time
                            while (true)
                            {
                                team t0_squad_save_1 = new team();
                                team t0_squad_save_2 = new team();

                                // Parse the saves
                                List<player> t0_player_table_1 = new List<player>();
                                List<player> t0_player_table_2 = new List<player>();

                                t0_player_table_1 = Importer.save_importer(switches.input_file);
                                t0_player_table_2 = Importer.save_importer(switches.compare_file);

                                // What team to check?
                                checker.team_input(t0_squad_save_1);

                                t0_squad_save_2.teamID = t0_squad_save_1.teamID;
                                t0_squad_save_2.team_name = t0_squad_save_1.team_name;

                                // Construct the two teams
                                checker.teambuilding(t0_player_table_1, t0_squad_save_1);
                                checker.teambuilding(t0_player_table_2, t0_squad_save_2);

                                // Compare the teams
                                comparer.compare_teams(t0_squad_save_1, t0_squad_save_2);

                                Console.WriteLine();
                                Console.WriteLine("Differences: " + variables.errors);
                                Console.WriteLine("Compare completed!");
                                Console.WriteLine();
                            }
                            break;

                        case 1: // Save/Export

                            team t1_squad_save = new team();
                            team t1_squad_export = new team();

                            // Parse the texport.bin
                            t1_squad_export = Importer.export_importer(switches.compare_file);

                            Console.WriteLine();
                            Console.WriteLine("Comparing " + t1_squad_export.team_name);
                            Console.WriteLine();

                            // Now we know what team we're using, parse the edit.bin
                            List<player> t1_player_table = new List<player>();

                            t1_player_table = Importer.save_importer(switches.input_file);

                            t1_squad_save.teamID = t1_squad_export.teamID;
                            t1_squad_save.team_name = t1_squad_export.team_name;

                            // Construct that team
                            checker.teambuilding(t1_player_table, t1_squad_save);

                            // Compare the teams
                            comparer.compare_teams(t1_squad_save, t1_squad_export);

                            break;

                        case 2: // Export/Save

                            team t2_squad_save = new team();
                            team t2_squad_export = new team();

                            // Parse the texport.bin
                            t2_squad_export = Importer.export_importer(switches.input_file);

                            Console.WriteLine();
                            Console.WriteLine("Comparing " + t2_squad_export.team_name);
                            Console.WriteLine();

                            // Now we know what team we're using, parse the edit.bin
                            List<player> t2_player_table = new List<player>();

                            t2_player_table = Importer.save_importer(switches.compare_file);

                            t2_squad_save.teamID = t2_squad_export.teamID;
                            t2_squad_save.team_name = t2_squad_export.team_name;

                            // Construct that team
                            checker.teambuilding(t2_player_table, t2_squad_save);

                            // Compare the teams
                            comparer.compare_teams(t2_squad_save, t2_squad_export);

                            break;

                        case 3: // Export/Export

                            team t3_squad_export_1 = new team();
                            team t3_squad_export_2 = new team();

                            // Parse the texport.bins
                            t3_squad_export_1 = Importer.export_importer(switches.input_file);
                            t3_squad_export_2 = Importer.export_importer(switches.compare_file);

                            // Are they exports for the same team?
                            if (t3_squad_export_1.teamID != t3_squad_export_2.teamID)
                            {
                                Console.WriteLine("\nThe two exports have different teams! Cancelling comparison");
                                Console.WriteLine("\t\t(" + t3_squad_export_1.team_name + " and " + t3_squad_export_2.team_name + ")");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Comparing " + t3_squad_export_1.team_name);
                                Console.WriteLine();

                                // Compare the teams
                                comparer.compare_teams(t3_squad_export_1, t3_squad_export_2);
                            }

                            break;

                        default:
                            // Oh shit nigga what are you doing
                            Console.WriteLine();
                            Console.WriteLine("Invalid input files");
                            Console.WriteLine("You really shouldn't be seeing this error. If you are, you dun goof'd somehow");
                            Console.WriteLine("Check the ini is pointing at the correct files");
                            Console.WriteLine();
                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Differences: " + variables.errors);
                    Console.WriteLine("Compare completed!");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }
}
