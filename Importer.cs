using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AATF_15
{
    public class player
    {
        // Player Info
        public int id;
        public string name;
        public string shirt_name;
        public int nationality;

        // Team
        public int Team_id;
        public string Team_name;

        // Position Info
        // 0 = GK
        // 1 = CB
        // 2 = LB
        // 3 = RB
        // 4 = DMF
        // 5 = CMF
        // 6 = LMF
        // 7 = RMF
        // 8 = AMF
        // 9 = LWF
        // 10 = RWF
        // 11 = SS
        // 12 = CF
        public int position;
        public int[] PosRats = new int[13];
        public string gk;
        public string cb;
        public string rb;
        public string lb;
        public string dmf;
        public string cmf;
        public string rmf;
        public string lmf;
        public string amf;
        public string rwf;
        public string lwf;
        public string ss;
        public string cf;

        // Player Info 2
        public int height;
        public int weight;
        public int age;
        public int stronger_foot;

        // Stats
        public int Attacking_Prowess;
        public int Ball_Control;
        public int Dribbling;
        public int Low_Pass;
        public int Lofted_Pass;
        public int Finishing;
        public int Place_Kicking;
        public int Controlled_Spin; // Swerve
        public int Header;
        public int Defensive_Prowess;
        public int Ball_Winning;
        public int Kicking_Power;
        public int Speed;
        public int Explosive_Power;
        public int Body_Balance;
        public int Jump;
        public int Goalkeeping;
        public int Saving;
        public int Stamina;
        public int Form;

        // Form
        public int Injury_Resistance;

        // Footage
        public int Weak_Foot_Accuracy;
        public int Weak_Foot_Usage;

        // Playing Style
        public int playing_style;

        // Playing Skills
        public int[] Cards_Style = new int[7];
        public int[] Cards_Skills = new int[22];
/*
        public bool Trickster;
        public bool Mazing_Run;
        public bool Speeding_Bullet;
        public bool Incisive_Run;
        public bool Long_Ball_Expert;
        public bool Early_Cross;
        public bool Long_Ranger;

        public bool Scissors_Feint;
        public bool Flip_Flap;
        public bool Marseille_Turn;
        public bool Sombrero;
        public bool Cut_Behind;
        public bool Scotch_Move;
        public bool Long_Range_Drive;
        public bool Knuckle_Shot;
        public bool Acrobatic_Finishing;
        public bool First_Time_Shot;
        public bool One_Touch_Pass;
        public bool Weighted_Pass;
        public bool Pinpoint_Crossing;
        public bool Outside_Curler;
        public bool Low_Punt_Trajectory;
        public bool Long_Throw;
        public bool GK_Long_Throw;
        public bool Man_Marking;
        public bool Track_Back;
        public bool Captaincy;
        public bool Super_Sub;
        public bool Fighting_Spirit;
        */
        // Player Definitions
        public bool is_gold;
        public bool is_silver;
        public bool is_regular;
        public bool is_goalkeeper;

        public bool is_gold_system1;
        public bool is_silver_system1;
        public bool is_regular_system1;
        public bool is_goalkeeper_system1;

        public bool is_defender;
        public bool is_midfielder;
        public bool is_striker;

        // Player Position Proficiency
        public bool position_gk;
        public bool position_cb;
        public bool position_lb;
        public bool position_rb;
        public bool position_dmf;
        public bool position_cmf;
        public bool position_lmf;
        public bool position_rmf;
        public bool position_amf;
        public bool position_lwf;
        public bool position_rwf;
        public bool position_ss;
        public bool position_cf;
    }

    public class Importer
    {
        public static int pointer;

        private static char[] chars_to_trim = { '\0' };

        static int readPlayerID(byte[] chunk)
        {
            byte[] playerid_hex = new byte[4];
            int playerid = 0;

            Array.Copy(chunk, 0, playerid_hex, 0, 4);
            playerid = BitConverter.ToInt32(playerid_hex, 0);

            return playerid;
        }

        static string readPlayerName(byte[] ebin)
        {
            int namesize = 46;
            byte[] playername_hex = new byte[namesize];
            string playername = null;

            int i = 0;
            int k = 0;

            for (i = pointer; i < pointer + namesize; i++)
            {
                if (ebin[i] != 0)
                {
                    playername_hex[k] = ebin[i];
                    k++;
                }
            }

            // Condense to the actual size
            byte[] playername_hex_sized = new byte[k];

            Array.Copy(playername_hex, 0, playername_hex_sized, 0, k);

            playername = System.Text.Encoding.Default.GetString(playername_hex_sized);

            // Move the pointer forward
            pointer += namesize;

            return playername;
        }

        static string texPlayerName(byte[] chunk)
        {
            int max_char = 25;

            byte[] texport_player_name = new byte[max_char];

            Array.Copy(chunk, 48, texport_player_name, 0, max_char);

            string player_name = System.Text.Encoding.Default.GetString(texport_player_name);

            return player_name.TrimEnd(chars_to_trim);
        }

        static string readShirtName(byte[] ebin)
        {
            int shirtsize = 18;
            byte[] shirtname_hex = new byte[shirtsize];
            string shirtname = null;

            int i = 0;
            int k = 0;

            for (i = pointer; i < pointer + shirtsize; i++)
            {
                if (ebin[i] != 0)
                {
                    shirtname_hex[k] = ebin[i];
                    k++;
                }
            }

            // Condense to the actual size
            byte[] shirtname_hex_sized = new byte[k];

            Array.Copy(shirtname_hex, 0, shirtname_hex_sized, 0, k);

            shirtname = System.Text.Encoding.Default.GetString(shirtname_hex_sized);

            // Move the pointer forward
            pointer += shirtsize;

            return shirtname;
        }

        static string texShirtName(byte[] chunk)
        {
            int max_char = 16;

            byte[] texport_shirt_name = new byte[max_char];

            Array.Copy(chunk, 94, texport_shirt_name, 0, max_char);

            string shirt_name = System.Text.Encoding.Default.GetString(texport_shirt_name);

            return shirt_name.TrimEnd(chars_to_trim);
        }

        static int readMainPosition(byte[] chunk)
        {
            int last5;

            // Get last 5 bits of byte 31
            last5 = chunk[31] >> 3;

            // 0 = GK
            // 1 = CB
            // 2 = LB
            // 3 = RB
            // 4 = DMF
            // 5 = CMF
            // 6 = LMF
            // 7 = RMF
            // 8 = AMF
            // 9 = LWF
            // 10 = RWF
            // 11 = SS
            // 12 = CF

            return last5;
        }

        static int[] readPositionRatings(byte[] chunk)
        {
            int[] rat = new int[13];
            
            // GK - byte 40, bits 7-8
            rat[0] = chunk[40] & 0x03;

            // CB - byte 39, bits 5-6
            rat[1] = (chunk[39] & 0x0C) >> 2;

            // LB - byte 39, bits 3-4
            rat[2] = (chunk[39] & 0x30) >> 4;

            // RB - byte 39, bits 1-2
            rat[3] = chunk[39] >> 6;

            // DMF - byte 38, bits 5-6
            rat[4] = (chunk[38] & 0x0C) >> 2;

            // CMF - byte 38, bits 3-4
            rat[5] = (chunk[38] & 0x30) >> 4;

            // LMF - byte 38, bits 1-2
            rat[6] = chunk[38] >> 6;

            // RMF - byte 39, bits 7-8
            rat[7] = chunk[39] & 0x03;

            // AMF - byte 38, bits 7-8
            rat[8] = chunk[38] & 0x03;

            // LWF - byte 37, bits 3-4
            rat[9] = (chunk[37] & 0x30) >> 4;

            // RWF - byte 37, bits 1-2
            rat[10] = chunk[37] >> 6;

            // SS - byte 37, bits 5-6
            rat[11] = (chunk[37] & 0x0C) >> 2;

            // CF - byte 37, bits 7-8
            rat[12] = chunk[37] & 0x03;

            // 0 = C
            // 1 = B
            // 2 = A

            return rat;
        }

        static int readCountry(byte[] chunk)
        {
            return chunk[10];
        }

        static int readTeamID(int player_id, Hashtable team_table)
        {
            return (int)team_table[player_id];
        }

        static string readTeamName(int team_id, Hashtable teams_4cc)
        {
            return (string)teams_4cc[team_id];
        }

        static int readHeight(byte[] chunk)
        {
            return chunk[12];
        }

        static int readWeight(byte[] chunk)
        {
            return chunk[13];
        }

        static int readAge(byte[] chunk)
        {
            // Age is the last 3 bits of byte 31 and first 3 bits of byte 30
            int by31, by30;

            by31 = (chunk[31] & 0x07) << 3;
            by30 = (chunk[30] & 0xE0) >> 5;

            return by31 | by30;
        }

        static int readStrongerFoot(byte[] chunk)
        {
            // Stronger Foot is the 3rd bit from byte 44
            // 0 = R
            // 1 = L

            return (chunk[44] & 0x04) >> 2;
        }

        static int readAtkProw(byte[] chunk)
        {
            return chunk[16] & 0x7F;
        }

        static int readDribbling(byte[] chunk)
        {
            int by32, by33;

            by33 = (chunk[33] & 0x0F) << 3;
            by32 = (chunk[32] & 0xE0) >> 5;

            return by33 | by32;
        }

        static int readBallControl(byte[] chunk)
        {
            return chunk[20] & 0x7F;
        }

        static int readLowPass(byte[] chunk)
        {
            int by22, by21;

            by22 = (chunk[22] & 0x1F) << 2;
            by21 = (chunk[21] & 0xC0) >> 6;

            return by22 | by21;
        }

        static int readLoftedPass(byte[] chunk)
        {
            int by23, by22;

            by23 = (chunk[23] & 0x0F) << 3;
            by22 = (chunk[22] & 0xE0) >> 5;

            return by23 | by22;
        }

        static int readFinishing(byte[] chunk)
        {
            int by21, by20;

            by21 = (chunk[21] & 0x3F) << 1;
            by20 = (chunk[20] & 0x80) >> 7;

            return by21 | by20;
        }

        static int readPlaceKicking(byte[] chunk)
        {
            return chunk[24] & 0x7F;
        }

        static int readControlledSpin(byte[] chunk)
        {
            int by25, by24;

            by25 = (chunk[25] & 0x3F) << 1;
            by24 = (chunk[24] & 0x80) >> 7;

            return by25 | by24;
        }

        static int readHeader(byte[] chunk)
        {
            int by34, by33;

            by34 = (chunk[34] & 0x07) << 4;
            by33 = (chunk[33] & 0xF0) >> 4;

            return by34 | by33;
        }

        static int readDefProw(byte[] chunk)
        {
            int by17, by16;

            by17 = (chunk[17] & 0x3F) << 1;
            by16 = (chunk[16] & 0x01);

            return by17 | by16;
        }

        static int readBallWinning(byte[] chunk)
        {
            return (chunk[41] & 0x7F);
        }

        static int readKickingPower(byte[] chunk)
        {
            int by42, by41;

            by42 = (chunk[42] & 0x3F) << 1;
            by41 = (chunk[41] & 0x80) >> 7;

            return by42 | by41;
        }

        static int readSpeed(byte[] chunk)
        {
            int by27, by26;

            by27 = (chunk[27] & 0x0F) << 3;
            by26 = (chunk[26] & 0xE0) >> 5;

            return by27 | by26;
        }

        static int readExplosivePower(byte[] chunk)
        {
            return (chunk[28] & 0x7F);
        }

        static int readBodyBalance(byte[] chunk)
        {
            int by35, by34;

            by35 = (chunk[35] & 0x03) << 5;
            by34 = (chunk[34] & 0xF8) >> 3;

            return by35 | by34;
        }

        static int readJump(byte[] chunk)
        {
            int by29, by28;

            by29 = (chunk[29] & 0x3F) << 1;
            by28 = (chunk[28] & 0x80) >> 7;

            return by29 | by28;
        }

        static int readGoalkeeping(byte[] chunk)
        {
            int by18, by17;

            by18 = (chunk[18] & 0x1F) << 2;
            by17 = (chunk[17] & 0xC0) >> 6;

            return by18 | by17;
        }

        static int readSaving(byte[] chunk)
        {
            int by26, by25;

            by26 = (chunk[26] & 0x1F) << 2;
            by25 = (chunk[25] & 0xC0) >> 6;

            return by26 | by25;
        }

        static int readStamina(byte[] chunk)
        {
            int by30, by29;

            by30 = (chunk[30] & 0x1F) << 2;
            by29 = (chunk[29] & 0xC0) >> 6;

            return by30 | by29;
        }

        static int readForm(byte[] chunk)
        {
            return ((chunk[27] & 0xF0) >> 4) + 1;
        }

        static int readInjuryTol(byte[] chunk)
        {
            return ((chunk[35] & 0x1C) >> 2) + 1;
        }

        static int readWeakFootUsage(byte[] chunk)
        {
            return ((chunk[36] & 0xC0) >> 6) + 1;
        }

        static int readWeakFootAccuracy(byte[] chunk)
        {
            return ((chunk[23] & 0x30) >> 4) + 1;
        }

        static int readPlayerStyle(byte[] chunk)
        {
            // 0 = N/A
            // 1 = Goal Poacher
            // 2 = Dummy Runner
            // 3 = Fox in the Box
            // 4 = Prolific Winger
            // 5 = Classic No10
            // 6 = Hole Player
            // 7 = Box to Box
            // 8 = Anchor Man
            // 9 = The Destroyer
            // 10 = Extra Frontman
            // 11 = Offensive Fullback
            // 12 = Defensive Fullback
            // 13 = Target Man
            // 14 = Creative Playmaker
            // 15 = Build Up
            // 16 = N/A
            // 17 = Offensive Goalkeeper
            // 18 = Defensive Goalkeeper
            
            return chunk[32] & 0x1F;
        }

        static int[] readCardsPlayStyles(byte[] chunk)
        {
            int[] cards = new int[7];

            // by44 = 54321xxx
            // by45 = xxxxxx76

            cards[0] = (chunk[44] & 0x08) >> 3;
            cards[1] = (chunk[44] & 0x10) >> 4;
            cards[2] = (chunk[44] & 0x20) >> 5;
            cards[3] = (chunk[44] & 0x40) >> 6;
            cards[4] = (chunk[44] & 0x80) >> 7;
            cards[5] = (chunk[45] & 0x01);
            cards[6] = (chunk[45] & 0x02) >> 1;

            // 1 = Yes, 0 = No
            // [0] = Trickster
            // [1] = Mazing Run
            // [2] = Speeding Bullet
            // [3] = Incisive Run
            // [4] = Long Ball Expert
            // [5] = Early Cross
            // [6] = Long Ranger

            return cards;
        }

        static int[] readCardsPlaySkills(byte[] chunk)
        {
            int[] cards = new int[22];

            // by45 = 654321xx
            // by46 = 43210987
            // by47 = 21098765

            cards[0]  = (chunk[45] & 0x04) >> 2;
            cards[1]  = (chunk[45] & 0x08) >> 3;
            cards[2]  = (chunk[45] & 0x10) >> 4;
            cards[3]  = (chunk[45] & 0x20) >> 5;
            cards[4]  = (chunk[45] & 0x40) >> 6;
            cards[5]  = (chunk[45] & 0x80) >> 7;
            cards[6]  = (chunk[46] & 0x01);
            cards[7]  = (chunk[46] & 0x02) >> 1;
            cards[8]  = (chunk[46] & 0x04) >> 2;
            cards[9]  = (chunk[46] & 0x08) >> 3;
            cards[10] = (chunk[46] & 0x10) >> 4;
            cards[11] = (chunk[46] & 0x20) >> 5;
            cards[12] = (chunk[46] & 0x40) >> 6;
            cards[13] = (chunk[46] & 0x80) >> 7;
            cards[14] = (chunk[47] & 0x01);
            cards[15] = (chunk[47] & 0x02) >> 1;
            cards[16] = (chunk[47] & 0x04) >> 2;
            cards[17] = (chunk[47] & 0x08) >> 3;
            cards[18] = (chunk[47] & 0x10) >> 4;
            cards[19] = (chunk[47] & 0x20) >> 5;
            cards[20] = (chunk[47] & 0x40) >> 6;
            cards[21] = (chunk[47] & 0x80) >> 7;

            // 1 = Yes, 0 = No
            // [0] = Scissors Feint
            // [1] = Flip Flap
            // [2] = Marseille Turn
            // [3] = Sombrero
            // [4] = Cut Behind Turn
            // [5] = Scotch Move
            // [6] = Long Range Drive
            // [7] = Knuckle Shot
            // [8] = Acrobatic Finishing
            // [9] = First Time Shot
            // [10] = One Touch Pass
            // [11] = Weighted Pass
            // [12] = Pinpoint Crossing
            // [13] = Outside Curler
            // [14] = Low Punt Trajectory
            // [15] = Long Throw
            // [16] = GK Long Throw
            // [17] = Man Marking
            // [18] = Track Back
            // [19] = Captaincy
            // [20] = Super Sub
            // [21] = Fighting Spirit

            return cards;
        }

        public static team export_importer(string input_file)
        {
            // Create a new team
            team squad = new team();

            // Import the raw, encrypted texport.bin
            byte[] raw_texport;
            raw_texport = File.ReadAllBytes(input_file);

            // Decrypt it
            byte[] texport;
            texport = BinFileUtility.BinFile.decryptFile(raw_texport);

            // Go 128 bytes in to get the team name
            int team_name_offset = 128;

            byte[] texport_team_name = new byte[10];

            Array.Copy(texport, team_name_offset, texport_team_name, 0, 10);

            string team_name_str = System.Text.Encoding.Default.GetString(texport_team_name);

            // Setup teams
            Hashtable teams_4cc = new Hashtable();
            teams_4cc = Lookup.setup_teams_4cc();

            // Since we don't have access to the team table, we have it hardcoded
            Hashtable team_table = new Hashtable();
            team_table = Lookup.setup_team_table();

            squad.team_name = team_name_str.TrimEnd(chars_to_trim);

            // Get the teamID
            int team_ID_offset = 94524;
            byte[] texport_team_ID = new byte[2];

            Array.Copy(texport, team_ID_offset, texport_team_ID, 0, 2);

            squad.teamID = BitConverter.ToInt16(texport_team_ID, 0);

            // Go to the first player in the export
            int player1_offset = 5338532;

            // Set the pointer
            pointer = player1_offset;
            
            // Loop through all the players
            while (true)
            {
                // Now we have a pointer to the start of the first player
                int chunk_size = 180;
                byte[] chunk = new byte[chunk_size];
                Array.Copy(texport, pointer, chunk, 0, chunk_size);

                // Create a new Player
                player line = new player();

                line.id = readPlayerID(chunk);

                if (line.id == 0)
                {
                    break;
                }

                line.name = texPlayerName(chunk);
                line.shirt_name = texShirtName(chunk);

                line.Team_id = readTeamID(line.id, team_table);
                line.Team_name = readTeamName(line.Team_id, teams_4cc);

                line.position = readMainPosition(chunk);
                line.PosRats = readPositionRatings(chunk);
                line.nationality = readCountry(chunk);

                line.height = readHeight(chunk);
                line.weight = readWeight(chunk);
                line.age = readAge(chunk);

                line.stronger_foot = readStrongerFoot(chunk);

                line.Attacking_Prowess = readAtkProw(chunk);
                line.Dribbling = readDribbling(chunk);
                line.Ball_Control = readBallControl(chunk);
                line.Low_Pass = readLowPass(chunk);
                line.Lofted_Pass = readLoftedPass(chunk);
                line.Finishing = readFinishing(chunk);
                line.Place_Kicking = readPlaceKicking(chunk);
                line.Controlled_Spin = readControlledSpin(chunk);
                line.Header = readHeader(chunk);
                line.Defensive_Prowess = readDefProw(chunk);
                line.Ball_Winning = readBallWinning(chunk);
                line.Kicking_Power = readKickingPower(chunk);
                line.Speed = readSpeed(chunk);
                line.Explosive_Power = readExplosivePower(chunk);
                line.Body_Balance = readBodyBalance(chunk);
                line.Jump = readJump(chunk);
                line.Goalkeeping = readGoalkeeping(chunk);
                line.Saving = readSaving(chunk);
                line.Stamina = readStamina(chunk);

                line.Form = readForm(chunk);
                line.Injury_Resistance = readInjuryTol(chunk);
                line.Weak_Foot_Usage = readWeakFootUsage(chunk);
                line.Weak_Foot_Accuracy = readWeakFootAccuracy(chunk);
                line.playing_style = readPlayerStyle(chunk);
                line.Cards_Style = readCardsPlayStyles(chunk);
                line.Cards_Skills = readCardsPlaySkills(chunk);

                // Add to the global table
                squad.team_players.Add(line);

                // DEBUG - add to list of players
                squad.team_names.Add(line.name);

                pointer += chunk_size;
            }

            // Count how many players were in the export
            int num_of_players = squad.team_players.Count;

            if (num_of_players > constants.players_per_team)
            {
                Console.WriteLine("ERROR: Export has too many players!");
                Console.WriteLine("\t\t(Has " + num_of_players + ", should have " + constants.players_per_team + ")");
                Console.WriteLine();
                variables.errors++;
            }
            else if (num_of_players < constants.players_per_team)
            {
                Console.WriteLine("ERROR: Export has too few players!");
                Console.WriteLine("\t\t(Has " + num_of_players + ", should have " + constants.players_per_team + ")");
                Console.WriteLine();
                variables.errors++;
            }
            else
            {
                // Correct number of players
            }

            return squad;
        }

        public static List<player> save_importer(string input_file)
        {
            // Import the raw, encrypted EDIT.bin
            byte[] raw_ebin;
            raw_ebin = File.ReadAllBytes(input_file);

            // Decrypt it
            byte[] ebin;
            ebin = PES16Decrypter.decryptFile(raw_ebin);

            List<player> player_table = new List<player>();
            Hashtable team_table = new Hashtable();
            Hashtable teams_4cc = new Hashtable();

            // Setup teams
            teams_4cc = Lookup.setup_teams_4cc();
            team_table = import_team_table(ebin, teams_4cc);

            // Go 384 bytes in, get the size of the png
            int first_offet = 384;
            int second_offset = 80;
            int png_size = 0;

            // Set the pointer
            pointer = 0;

            png_size = BitConverter.ToInt32(ebin, first_offet);

            // Move pointer to after png
            pointer = png_size + first_offet + 4 + second_offset;

            // Jump to 5111808 blocks in, here its safe to assume we're before the first team but not too far
            int block_jump = 5111808;

            // Iterate until you find a 1
            int i = 0;
            int ind = block_jump;

            while (i != 1)
            {
                ind++;
                i = ebin[ind];
            }

            while (true)
            {
                // Now we have a pointer to the start of the first team
                // Grab the next 48 bytes
                int size_of_player = 48;

                byte[] chunk = new byte[size_of_player];
                Array.Copy(ebin, pointer, chunk, 0, size_of_player);

                // Set the new pointer for the next iteration
                pointer += size_of_player;

                // Create a new Player
                player line = new player();

                // Read PlayerID
                line.id = readPlayerID(chunk);
                line.name = readPlayerName(ebin);
                line.shirt_name = readShirtName(ebin);

                if (line.id == 0)
                {
                    // If the playerID is zero, we've reach the end of the player table
                    break;
                }

                // Check if the player is a valid 4cc player
                if (team_table.Contains(line.id))
                {
                    // Read Values
                    line.position = readMainPosition(chunk);
                    line.PosRats = readPositionRatings(chunk);
                    line.nationality = readCountry(chunk);

                    line.Team_id = readTeamID(line.id, team_table);
                    line.Team_name = readTeamName(line.Team_id, teams_4cc);

                    line.height = readHeight(chunk);
                    line.weight = readWeight(chunk);
                    line.age = readAge(chunk);
                    line.stronger_foot = readStrongerFoot(chunk);

                    line.Attacking_Prowess = readAtkProw(chunk);
                    line.Dribbling = readDribbling(chunk);
                    line.Ball_Control = readBallControl(chunk);
                    line.Low_Pass = readLowPass(chunk);
                    line.Lofted_Pass = readLoftedPass(chunk);
                    line.Finishing = readFinishing(chunk);
                    line.Place_Kicking = readPlaceKicking(chunk);
                    line.Controlled_Spin = readControlledSpin(chunk);
                    line.Header = readHeader(chunk);
                    line.Defensive_Prowess = readDefProw(chunk);
                    line.Ball_Winning = readBallWinning(chunk);
                    line.Kicking_Power = readKickingPower(chunk);
                    line.Speed = readSpeed(chunk);
                    line.Explosive_Power = readExplosivePower(chunk);
                    line.Body_Balance = readBodyBalance(chunk);
                    line.Jump = readJump(chunk);
                    line.Goalkeeping = readGoalkeeping(chunk);
                    line.Saving = readSaving(chunk);
                    line.Stamina = readStamina(chunk);

                    line.Form = readForm(chunk);
                    line.Injury_Resistance = readInjuryTol(chunk);
                    line.Weak_Foot_Usage = readWeakFootUsage(chunk);
                    line.Weak_Foot_Accuracy = readWeakFootAccuracy(chunk);
                    line.playing_style = readPlayerStyle(chunk);
                    line.Cards_Style = readCardsPlayStyles(chunk);
                    line.Cards_Skills = readCardsPlaySkills(chunk);

                    // Add to the global table
                    player_table.Add(line);
                }
            }

            return player_table;
        }

        public static bool is_edit_bin(string input_file)
        {
            FileInfo bin = new FileInfo(input_file);
            long bin_length = bin.Length;

            if (bin_length > 5709223)
            {
                // edit.bin
                return true;
            }
            else
            {
                // texport.bin
                return false;
            }
        }

        public static Hashtable import_team_table(byte[] ebin, Hashtable teams_4cc)
        {
            Hashtable team_table = new Hashtable();

            // Jump to the start of the team table
            int offset_team1 = 5158995;

            pointer = offset_team1;

            while (true)
            {
                // Now we have a pointer to the start of the team
                // Grab the next 164 bytes
                int size_of_team = 164;

                byte[] chunk = new byte[size_of_team];
                Array.Copy(ebin, pointer, chunk, 0, size_of_team);

                byte[] num = new byte[4];

                // TeamID for this player is 32 bytes in
                Array.Copy(chunk, 32, num, 0, 4);

                int teamID = BitConverter.ToInt32(num, 0);

                if (teamID == 262143)
                {
                    // Reached end of the team table
                    break;
                }

                if (teams_4cc.ContainsKey(teamID))
                {
                    // Valid 4cc team
                    // Jump to the first player
                    int pos = 36;
                    int playerID;

                    while (true)
                    {
                        Array.Copy(chunk, pos, num, 0, 4);
                        playerID = BitConverter.ToInt32(num, 0);

                        if (playerID == 0)
                        {
                            // Reached the end of the team
                            break;
                        }

                        // Add the player to the table
                        team_table.Add(playerID, teamID);

                        // Iterate to the next player in the team
                        pos += 4;
                    }
                }

                pointer += size_of_team;
            }

            return team_table;
        }
    }
}
