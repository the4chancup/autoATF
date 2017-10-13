﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
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

    public class heightsystem
    {
        // constructor
        public heightsystem (uint id, uint[] limits, uint min_double_a, string desc, uint gkheight = 189)
        {
            // numeric identifier
            this.id = id;
            // description (used for printing when deducing system)
            this.desc = desc;
            // limits for each height tier
            this.limits = limits;
            // total height limit
            this.total_limit = 25;
            uint i = 0;
            for (i=0; i < constants.height_brackets.Length; ++i ) { this.total_limit += constants.height_brackets[i] * this.limits[i]; }
            // minimum bracket where two A positions are allowed
            this.min_double_a_bracket = min_double_a;
            // maximum height for goalkeepers; currently the same on both brackets
            this.max_gk_height = gkheight;
        }
        
        public uint id { get; set; }
        public uint[] limits { get; set; }
        public uint total_limit { get; set; }
        public uint min_double_a_bracket { get; set; }
        public string desc { get; set; }
        public uint max_gk_height { get; set; }
    }

    public static class constants
    {
        public const uint players_per_team = 23;

        // indexed by ptype values: 0 - GK, 1 - regular, 2 - silver, 3 - gold
        public static readonly uint[] stats = { 77, 77, 88, 99 };
        // Summer 2015 Ruleset - All players above 189cm in height get a variable stat nerf
        public static readonly uint[] stats_system1 = { 74, 74, 84, 94 };

        public static readonly uint[] form = { 4, 4, 8, 8 };
        
        public const uint weakfoot_accuracy = 2;
        public const uint weakfoot_usage = 2;

        public const uint weakfoot_manlet_height = 179;
        public const uint weakfoot_accuracy_manlet = 4;
        public const uint weakfoot_usage_manlet = 4;

        public const uint injury_tolerance = 3;

        // regular cup rules
        public static readonly uint[] card_limits = { 1, 2, 3, 4 };
        public static readonly uint[] card_minimum = { 0, 0, 0, 0 };
        public static readonly uint[] free_trick_cards = { 0, 0, 1, 1 };

        // defines which cards qualify for the free trick cards
        public static readonly uint[] trick_cards = { 0, 1, 2, 3, 4, 5, 16 };

        public const uint positions_minimum_gk = 2;
        public const uint positions_minimum_def = 2;
        public const uint positions_minimum_mf = 1;
        public const uint positions_minimum_fw = 1;

        public const uint players_gold = 2;
        public const uint players_silver = 2;
        public const uint players_regular_and_gk = 19;

        public const uint height_maximum_pes = 210;
        public const uint height_maximum_4cc = 205;
        public const uint height_minimum_pes = 148;

        // height brackets as array
        public static readonly uint[] height_brackets = { 200, 195, 190, 185, 180, 155 };

        // Height Abuse System 1
        public static readonly heightsystem system1 = new heightsystem(1, new uint[] { 0, 2, 2, 6, 7, 6 }, 999, "all players above 189cm have a variable stats nerf");
        // Height Abuse System 2
        public static readonly heightsystem system2 = new heightsystem(2, new uint[] { 0, 0, 0, 10, 7, 6 }, 5, "no players above 189cm; two A positions for players below 180cm");

        // Age Abuse
        public const uint age_maximum = 50;
        public const uint age_minimum = 15;

        // free and required styles; these lists must be sorted
        public static readonly uint[] free_styles = { };
        public static readonly uint[] required_styles = { };

        // official event - no skills free
        public static readonly uint[] free_skills = { };

        // official event - no required skills
        public static readonly uint[] required_skills = { };

        // Style names
        public static readonly string[] style_names =
        {
            "Trickster",        // 0
            "Mazing Run",       // 1
            "Speeding Bullet",  // 2
            "Incisive Run",     // 3
            "Long Ball Expert", // 4
            "Early Cross",      // 5
            "Long Ranger"       // 6
        };
        // Skill names
        public static readonly string[] skill_names =
        {
            "Scissors Feint",             //  0
            "Flip Flap",                  //  1
            "Marseille Turn",             //  2
            "Sombrero",                   //  3
            "Cut Behind Turn",            //  4
            "Scotch Move",                //  5
            "Heading",                    //  6
            "Long Range Drive",           //  7
            "Knuckle Shot",               //  8
            "Acrobatic Finishing",        //  9
            "Heel Trick",                 // 10
            "First Time Shot",            // 11
            "One Touch Pass",             // 12
            "Weighted Pass",              // 13
            "Pinpoint Crossing",          // 14
            "Outside Curler",             // 15
            "Rabona",                     // 16
            "Low Lofted Pass",            // 17
            "Low Punt Trajectory",        // 18
            "Long Throw",                 // 19
            "GK Long Throw",              // 20
            "Malicia",                    // 21
            "Man Marking",                // 22
            "Track Back",                 // 23
            "Acrobatic Clear",            // 24
            "Captaincy",                  // 25
            "Super Sub",                  // 26
            "Fighting Spirit"             // 27
        };
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

            Console.Title = "autoATF - PES 2017 - Autumn 2017 Edition - v1.4 - C# can eat a wall of dicks";

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
