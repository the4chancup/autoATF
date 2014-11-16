using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;
using FileHelpers.RunTime;

namespace ATF_test
{
    public class switches
    {
        static string _input_file;

        public static string input_file
        {
            get
            {
                return _input_file;
            }
            set
            {
                _input_file = value;
            }
        }

        static bool _enable_stats_check;
        static bool _enable_form_check;
        static bool _enable_weakfoot_check;
        static bool _enable_player_position_check;
        static bool _enable_team_position_check;
        static bool _enable_injury_check;
        static bool _enable_player_card_check;
        static bool _enable_team_card_check;
        static bool _enable_captaincy_card_check;
        static bool _enable_player_count_check;
        static bool _enable_ggss_check;
        static bool _enable_height_abuse_check;

        public static bool enable_stats_check
        {
            get
            {
                return _enable_stats_check;
            }
            set
            {
                _enable_stats_check = value;
            }
        }
        public static bool enable_form_check
        {
            get
            {
                return _enable_form_check;
            }
            set
            {
                _enable_form_check = value;
            }
        }
        public static bool enable_weakfoot_check
        {
            get
            {
                return _enable_weakfoot_check;
            }
            set
            {
                _enable_weakfoot_check = value;
            }
        }
        public static bool enable_player_position_check
        {
            get
            {
                return _enable_player_position_check;
            }
            set
            {
                _enable_player_position_check = value;
            }
        }
        public static bool enable_team_position_check
        {
            get
            {
                return _enable_team_position_check;
            }
            set
            {
                _enable_team_position_check = value;
            }
        }
        public static bool enable_injury_check
        {
            get
            {
                return _enable_injury_check;
            }
            set
            {
                _enable_injury_check = value;
            }
        }
        public static bool enable_player_card_check
        {
            get
            {
                return _enable_player_card_check;
            }
            set
            {
                _enable_player_card_check = value;
            }
        }
        public static bool enable_team_card_check
        {
            get
            {
                return _enable_team_card_check;
            }
            set
            {
                _enable_team_card_check = value;
            }
        }
        public static bool enable_captaincy_card_check
        {
            get
            {
                return _enable_captaincy_card_check;
            }
            set
            {
                _enable_captaincy_card_check = value;
            }
        }
        public static bool enable_player_count_check
        {
            get
            {
                return _enable_player_count_check;
            }
            set
            {
                _enable_player_count_check = value;
            }
        }
        public static bool enable_ggss_check
        {
            get
            {
                return _enable_ggss_check;
            }
            set
            {
                _enable_ggss_check = value;
            }
        }
        public static bool enable_height_abuse_check
        {
            get
            {
                return _enable_height_abuse_check;
            }
            set
            {
                _enable_height_abuse_check = value;
            }
        }
    }
    
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

        public const uint stats_gold       = 99;
        public const uint stats_silver     = 88;
        public const uint stats_regular    = 77;
        public const uint stats_goalkeeper = 70;

        public const uint form_gold        = 8;
        public const uint form_silver      = 8;
        public const uint form_regular     = 5;
        public const uint form_goalkeeper  = 5;

        public const uint weakfoot_accuracy = 4;
        public const uint weakfoot_usage    = 4;

        public const uint weakfoot_manlet_height    = 179;
        public const uint weakfoot_accuracy_manlet  = 8;
        public const uint weakfoot_usage_manlet     = 8;

        public const uint injury_tolerance          = 3;

        public const uint cards_limit_regular       = 2;
        public const uint cards_limit_silver        = 3;
        public const uint cards_limit_gold          = 4;
        public const int cards_limit_team           = 25;

        public const uint positions_minimum_gk      = 2;
        public const uint positions_minimum_def     = 2;
        public const uint positions_minimum_mf      = 2;
        public const uint positions_minimum_fw      = 1;

        public const uint players_gold              = 2;
        public const uint players_silver            = 2;
        public const uint players_regular_and_gk    = 19;

        public const uint height_maximum_pes        = 210;
        public const uint height_maximum_4cc        = 205;
        public const uint height_bracket_1          = 200;
        public const uint height_bracket_2          = 195;
        public const uint height_bracket_3          = 190;
        public const uint height_bracket_4          = 185;
        public const uint height_bracket_5          = 180;
        public const uint height_bracket_6          = 175;
        public const uint height_bracket_7          = 170;
        public const uint height_bracket_8          = 165;
        public const uint height_minimum_pes        = 148;

        public const uint height_bracket_1_limit    = 1;
        public const uint height_bracket_2_limit    = 1;
        public const uint height_bracket_3_limit    = 2;
        public const uint height_bracket_4_limit    = 6;
        public const uint height_bracket_5_limit    = 7;
        public const uint height_bracket_6_limit    = 3;
        public const uint height_bracket_7_limit    = 2;
        public const uint height_bracket_8_limit    = 1;
        public const uint height_limit_total        = 4200; 
        
    }

    public class team
    {
        public string team_name;
        
        public List<player> team_players = new List<player>();
    }
    
    class Program
    {
        public static int Count_Bool(params bool[] args)
        {
            return args.Count(t => t);
        }

        public static List<string> teams_4cc()
        {
            List<string> teams = new List<string>();

            teams.Add("a");
            teams.Add("b");
            teams.Add("c");
            teams.Add("d");
            teams.Add("e");
            teams.Add("f");
            teams.Add("g");
            teams.Add("h");
            teams.Add("i");
            teams.Add("k");
            teams.Add("m");
            teams.Add("n");
            teams.Add("o");
            teams.Add("s");
            teams.Add("t");
            teams.Add("u");
            teams.Add("v");
            teams.Add("w");
            teams.Add("x");
            teams.Add("y");

            teams.Add("3");
            teams.Add("adv");
            teams.Add("an");
            teams.Add("asp");
            teams.Add("biz");
            teams.Add("cgl");
            teams.Add("ck");
            teams.Add("cm");
            teams.Add("co");
            teams.Add("diy");
            teams.Add("fa");
            teams.Add("fit");
            teams.Add("gd");
            teams.Add("gif");
            teams.Add("hm");
            teams.Add("hr");
            teams.Add("ic");
            teams.Add("int");
            teams.Add("jp");
            teams.Add("lgbt");
            teams.Add("lit");
            teams.Add("mlp");
            teams.Add("mu");
            teams.Add("out");
            teams.Add("po");
            teams.Add("pol");
            teams.Add("r9k");
            teams.Add("s4s");
            teams.Add("sci");
            teams.Add("soc");
            teams.Add("sp");
            teams.Add("tg");
            teams.Add("toy");
            teams.Add("trv");
            teams.Add("tv");
            teams.Add("vg");
            teams.Add("vp");
            teams.Add("vr");
            teams.Add("wg");
            teams.Add("wsg");

            return teams;
        }

        public static string team_input()
        {
            bool is_4cc_team = false;
            
            // Input team to be checked
            Console.WriteLine("Enter team name:\t(Without slashes)");
            string team_being_checked = Console.ReadLine();
            Console.WriteLine();

            List<string> valid_teams = teams_4cc();

            foreach(string line in valid_teams)
            {
                if(line.Equals(team_being_checked))
                {
                    is_4cc_team = true;
                }

            }

            if(is_4cc_team == false)
            {
                Console.WriteLine("ERROR: That is not a valid 4cc team");
                Console.WriteLine();
                variables.errors++;
            }

            // Remember to add the slashes back
            return "/" + team_being_checked + "/";
        }

        static void check_em(player[] input_table)
        {
            uint players = 0;

            // Create a structure for the team info
            team squad = new team();

            // Input team to be checked
            squad.team_name = team_input();

            // If you've triggered an error already, just stop
            if(variables.errors == 0)
            {
                // Player-specific checks

                // Loop through every player in the player table
                foreach (player line in input_table)
                {
                    // If that player is registered to the team you're checking, perform checks on them
                    if (line.Club == squad.team_name)
                    {
                        // Check Stats and set Gold/Silver/Regular/Goalkeeper marker
                        // This MUST be done first, as subsequent checks may need to use the markers
                        // NOTE: If a player fails this, they will not have a type marker set and so will fall through type checks
                        if (switches.enable_stats_check) { Check_Stats.check_stats(line); }

                        // Check Form against the player type
                        if (switches.enable_form_check) { Check_Form.check_form(line); }

                        // Check if manlets have correctly augmented weakfoot stats
                        // Check all other player have correct weakfoot stats
                        if (switches.enable_weakfoot_check) { Check_Weakfoot.check_manlet_weakfoot(line); }

                        // Check if players have the correct proficiency in their registered position
                        // Check that this is the only position they have proficiency in
                        if (switches.enable_player_position_check) { Check_Position.check_player_positions(line); }

                        // Check if players have the correct Injury Tolerance
                        if (switches.enable_injury_check) { Check_InjuryTolerance.check_injurytolerance(line); }

                        // Check if players have the right number of cards for their type
                        if (switches.enable_player_card_check) { Check_Cards.check_cards(line); }

                        // Add player to the squad structure for further team-wide checks
                        if (switches.enable_player_count_check) { squad.team_players.Add(line); }
                        players++;
                    }
                }

                // Team-wide checks

                // Check number of players in team. If none found, that means team doesn't exist in this save
                Console.WriteLine();
                if (switches.enable_player_count_check)
                {
                    if (players == 0)
                    {
                        Console.WriteLine("Team not found");
                    }
                    else if (players > 0 && players < constants.players_per_team)
                    {
                        Console.WriteLine(squad.team_name + " has " + (constants.players_per_team - players) + " players too few (Is " + players + ", should be " + constants.players_per_team + ")");
                        variables.errors++;
                    }
                    else if (players > constants.players_per_team)
                    {
                        Console.WriteLine(squad.team_name + " has " + (players - constants.players_per_team) + " players too many (Is " + players + ", should be " + constants.players_per_team + ")");
                        variables.errors++;
                    }
                }

                // Check GGSS allocation
                if (switches.enable_ggss_check) { Check_Stats.check_ggss(squad); }

                // Check the position allocations
                if (switches.enable_team_position_check) { Check_Position.check_team_positions(squad); }

                // Check total cards
                if (switches.enable_team_card_check) { Check_Cards.check_team_cards(squad); }

                // Check Captaincy cards
                if (switches.enable_captaincy_card_check) { Check_Cards.check_cards_captaincy(squad); }

                // Check Height Abuse
                if (switches.enable_height_abuse_check) { Height_Abuse.check_height_abuse(squad); }

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
        
        static void Main(string[] args)
        {
            variables.errors = 0;
            
            bool ini_setup = false;
            player[] input_table;

            Console.Title = "autoATF - Autumn 2014 Ruleset - Beta as fuck Edition";
            
            // INI setup
            ini_setup = Parser.setup_switches();

            // Only continue if the ini setup was successful, otherwise there will be no input file and the csv parser will fall over
            if (ini_setup)
            {
                // Parse the csv player table
                input_table = Parser.parse_csv();

                for (; ; )
                {
                    // Run through the checks
                    check_em(input_table);

                    // Reset the error count for the next team
                    variables.errors = 0;
                }
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
            
        }

    }
}
