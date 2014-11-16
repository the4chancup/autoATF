using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;
using FileHelpers.RunTime;
using System.Runtime.InteropServices;
using System.IO;

namespace ATF_test
{
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();
        }
    }

    [DelimitedRecord("$")]
    [IgnoreEmptyLines()]
    [IgnoreFirst(1)]
    public class player
    {
        // Player Info
        [FieldNullValue(typeof(uint), "0")]             public uint id;
        [FieldNullValue(typeof(string), null)]          public string name;
        [FieldNullValue(typeof(string), null)]          public string shirt_name;
        [FieldNullValue(typeof(uint), "0")]             public uint age;
        [FieldNullValue(typeof(string), null)]          public string nationality;
        [FieldNullValue(typeof(string), null)]          public string stronger_foot;
        [FieldNullValue(typeof(uint), "0")]             public uint height;
        [FieldNullValue(typeof(uint), "0")]             public uint weight;

        // Position Info
        [FieldNullValue(typeof(string), null)]        public string position;
        [FieldNullValue(typeof(string), null)]        public string gk;
        [FieldNullValue(typeof(string), null)]        public string cb;
        [FieldNullValue(typeof(string), null)]        public string lb;
        [FieldNullValue(typeof(string), null)]        public string rb;
        [FieldNullValue(typeof(string), null)]        public string dmf;
        [FieldNullValue(typeof(string), null)]        public string cmf;
        [FieldNullValue(typeof(string), null)]        public string lmf;
        [FieldNullValue(typeof(string), null)]        public string rmf;
        [FieldNullValue(typeof(string), null)]        public string amf;
        [FieldNullValue(typeof(string), null)]        public string lwf;
        [FieldNullValue(typeof(string), null)]        public string rwf;
        [FieldNullValue(typeof(string), null)]        public string ss;
        [FieldNullValue(typeof(string), null)]        public string cf;

        // Stats
        [FieldNullValue(typeof(uint), "0")]        public uint Attacking_Prowess;
        [FieldNullValue(typeof(uint), "0")]        public uint Ball_Control;
        [FieldNullValue(typeof(uint), "0")]        public uint Dribbling;
        [FieldNullValue(typeof(uint), "0")]        public uint Low_Pass;
        [FieldNullValue(typeof(uint), "0")]        public uint Lofted_Pass;
        [FieldNullValue(typeof(uint), "0")]        public uint Finishing;
        [FieldNullValue(typeof(uint), "0")]        public uint Place_Kicking;
        [FieldNullValue(typeof(uint), "0")]        public uint Controlled_Spin;
        [FieldNullValue(typeof(uint), "0")]        public uint Header;
        [FieldNullValue(typeof(uint), "0")]        public uint Defensive_Prowess;
        [FieldNullValue(typeof(uint), "0")]        public uint Ball_Winning;
        [FieldNullValue(typeof(uint), "0")]        public uint Kicking_Power;
        [FieldNullValue(typeof(uint), "0")]        public uint Speed;
        [FieldNullValue(typeof(uint), "0")]        public uint Explosive_Power;
        [FieldNullValue(typeof(uint), "0")]        public uint Body_Balance;
        [FieldNullValue(typeof(uint), "0")]        public uint Jump;
        [FieldNullValue(typeof(uint), "0")]        public uint Goalkeeping;
        [FieldNullValue(typeof(uint), "0")]        public uint Saving;
        [FieldNullValue(typeof(uint), "0")]        public uint Tenacity;
        [FieldNullValue(typeof(uint), "0")]        public uint Stamina;
        [FieldNullValue(typeof(uint), "0")]        public uint Form;

        // Form
        [FieldNullValue(typeof(uint), "0")]        public uint Injury_Tolerance;

        // Footage
        [FieldNullValue(typeof(uint), "0")]        public uint Weak_Foot_Usage;
        [FieldNullValue(typeof(uint), "0")]        public uint Weak_Foot_Accuracy;

        [FieldNullValue(typeof(uint), "0")]        public uint Playing_Styles;

        // Playing Skills
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Trickster;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Mazing_Run;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Speeding_Bullet;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Incisive_Run;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Long_Ball_Expert;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Early_Cross;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Long_Ranger;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Scissors_Feint;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Flip_Flap;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Marseille_Turn;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Sombrero;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Precise_Touch;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Long_Range_Drive;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Knuckle_Shot;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Acrobatic_Finishing;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool First_Time_Shot;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool One_Touch_Pass;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Weighted_Pass;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Pinpoint_Crossing;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Outside_Curler;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Low_Punt_Trajectory;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Long_Throw;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool GK_Long_Throw;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Man_Marking;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Track_Back;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Captaincy;
        [FieldNullValue(typeof(bool), "FALSE")]        public bool Super_Sub;

        // Playing Style cards
        [FieldNullValue(typeof(uint), "0")]        public uint Dribble_Style;
        [FieldNullValue(typeof(uint), "0")]        public uint FK_Style;
        [FieldNullValue(typeof(uint), "0")]        public uint Penalty_Style;
        [FieldNullValue(typeof(uint), "0")]        public uint Drop_Kick_Style;
        [FieldNullValue(typeof(uint), "0")]        public uint Goal_Cel_1;
        [FieldNullValue(typeof(uint), "0")]        public uint Goal_Cel_2;

        // National Team (Not used by 4cc)
        [FieldNullValue(typeof(string), null)]          public string National_Team;
        [FieldNullValue(typeof(uint), "0")]             public uint National_Team_Number;

        // Club (4cc team)
        [FieldNullValue(typeof(string), null)]          public string Club;
        [FieldNullValue(typeof(uint), "0")]             public uint Club_Number;

        // Random comma on the end, thanks PEES
        [FieldNullValue(typeof(string), null)]        public string truncate;

        // Player Definitions
        [FieldIgnored()]        public bool is_gold;
        [FieldIgnored()]        public bool is_silver;
        [FieldIgnored()]        public bool is_regular;
        [FieldIgnored()]        public bool is_goalkeeper;

        [FieldIgnored()]        public bool is_defender;
        [FieldIgnored()]        public bool is_midfielder;
        [FieldIgnored()]        public bool is_striker;

        // Player Position Proficiency
        [FieldIgnored()]        public bool position_gk;
        [FieldIgnored()]        public bool position_cb;
        [FieldIgnored()]        public bool position_lb;
        [FieldIgnored()]        public bool position_rb;
        [FieldIgnored()]        public bool position_dmf;
        [FieldIgnored()]        public bool position_cmf;
        [FieldIgnored()]        public bool position_lmf;
        [FieldIgnored()]        public bool position_rmf;
        [FieldIgnored()]        public bool position_amf;
        [FieldIgnored()]        public bool position_lwf;
        [FieldIgnored()]        public bool position_rwf;
        [FieldIgnored()]        public bool position_ss;
        [FieldIgnored()]        public bool position_cf;

        // Player card count
        [FieldIgnored()]        public int cards_sum;
    }

    public class Parser
    {
        public static bool setup_switches()
        {
            string input_switch = null;
            Console.Write("Parsing ini file...");

            // Load ini file
            IniFile ini = new IniFile(".//autoATF.ini");

            // Parse the csv input file name
            switches.input_file = ini.IniReadValue("Input", "CSVfilename");

            // Verification that the ini file is there
            if (switches.input_file == "")
            {
                Console.Write("\tFailed!");
                Console.WriteLine("\nERROR: ini file not found");
                Console.WriteLine("\nMake sure it is present in the same directory as the exe");
                Console.WriteLine();
                return false;
            }

            if(!File.Exists(switches.input_file))
            {
                Console.Write("\tFailed!");
                Console.WriteLine("\nERROR: specified csv file not found");
                Console.WriteLine("\nMake sure the csv file is present in the same directory as the exe");
                Console.WriteLine("\nMake sure the csv filename specified in the ini is correct");
                Console.WriteLine();
                return false;
            }


            // Check the FileHelpers.dll file is present, which contains the csv parser
            if (!File.Exists("FileHelpers.dll"))
            {
                Console.Write("\tFailed!");
                Console.WriteLine("\nERROR: dll file not found");
                Console.WriteLine("\nMake sure the FileHelpers.dll file is present in the same directory as the exe");
                Console.WriteLine();
                return false;
            }

            

            // Parse the checker switches
            // Check stats
            input_switch = ini.IniReadValue("Checkers", "Stats");
            if (input_switch.Equals("1")) { switches.enable_stats_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Form");
            if (input_switch.Equals("1")) { switches.enable_form_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Weakfoot");
            if (input_switch.Equals("1")) { switches.enable_weakfoot_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Player_Positions");
            if (input_switch.Equals("1")) { switches.enable_player_position_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Team_Positions");
            if (input_switch.Equals("1")) { switches.enable_team_position_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Injury_Tolerance");
            if (input_switch.Equals("1")) { switches.enable_injury_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Player_Cards");
            if (input_switch.Equals("1")) { switches.enable_player_card_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Team_Cards");
            if (input_switch.Equals("1")) { switches.enable_team_card_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Captaincy_Card");
            if (input_switch.Equals("1")) { switches.enable_captaincy_card_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Player_Count");
            if (input_switch.Equals("1")) { switches.enable_player_count_check = true; }

            input_switch = ini.IniReadValue("Checkers", "GGSS");
            if (input_switch.Equals("1")) { switches.enable_ggss_check = true; }

            input_switch = ini.IniReadValue("Checkers", "Height_Abuse");
            if (input_switch.Equals("1")) { switches.enable_height_abuse_check = true; }

            Console.Write("\tComplete!");
            Console.WriteLine();

            return true;
        }

        public static player[] parse_csv()
        {
            Console.WriteLine("Parsing CSV...");

            //Begin a new instance of the FileHelper Engine, inits as a class that the engine will feed data into
            FileHelperEngine engine = new FileHelperEngine(typeof(player));

            //Construct class Team, which reads data from test.csv
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

            player[] input_table = (player[])engine.ReadFile(@switches.input_file);

            if (engine.ErrorManager.HasErrors)
            {
                foreach (ErrorInfo err in engine.ErrorManager.Errors)
                {
                    Console.WriteLine("Error parsing player on line " + err.LineNumber);
                }
            }

            Console.WriteLine("Parsing Complete!");
            Console.WriteLine();

            return input_table;
        }
    }
}
