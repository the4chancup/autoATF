using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AATF
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
        public int Defensive_Prowess;

        public int Goalkeeping;
        public int Dribbling;
        public int Finishing;
        public int Low_Pass;
        public int Lofted_Pass;
        public int Header;
        public int Form;
        public int Controlled_Spin; // Swerve
        public int Saving; // Catching in PES16
        public int Clearing; // NEW PES16
        public int Reflexes; // NEW PES16

        public int Body_Balance; // Body Control in PES17
        public int Physical_Contact; // NEW PES17
        public int Kicking_Power;
        public int Explosive_Power;
        public int Jump;
        public int Ball_Control;
        public int Ball_Winning;
        public int Coverage; // NEW PES16
        public int Place_Kicking;
        public int Speed;
        public int Stamina;

        // Form
        public int Injury_Resistance;

        // Footage
        public int Weak_Foot_Accuracy;
        public int Weak_Foot_Usage;

        // Playing Style
        public int playing_style;

        // Playing Skills
        public int[] Cards_Style = new int[7];
        public int[] Cards_Skills = new int[28];

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

        // Aesthetic - NEW PES16
        public int commentary_name;
        public int ani_celebration_1;
        public int ani_celebration_2;
        public int ani_free_kick;
        public int ani_corner;
        public int ani_penalty;
        public int ani_arms_dribbling;
        public int ani_arms_running;
        public int ani_hunch_dribbling;
        public int ani_hunch_running;
    }

    public class Importer
    {
        public static int pointer;

        private static char[] chars_to_trim = { '\0' , 'þ' };

        static int readPlayerID(byte[] chunk)
        {
            byte[] playerid_hex = new byte[4];
            int playerid = 0;

            Array.Copy(chunk, 0, playerid_hex, 0, 4);
            playerid = BitConverter.ToInt32(playerid_hex, 0);

            return playerid;
        }

        static string readPlayerName(byte[] chunk)
        {
            int namesize = 46;
            byte[] playername_hex = new byte[namesize];
            string playername = null;

            Array.Copy(chunk, 0x34, playername_hex, 0, namesize);

            playername = System.Text.Encoding.Default.GetString(playername_hex);

            return playername.TrimEnd(chars_to_trim);
        }

        static string texPlayerName(byte[] chunk)
        {
            int max_char = 46;

            byte[] texport_player_name = new byte[max_char];

            Array.Copy(chunk, 0x34, texport_player_name, 0, max_char);

            string player_name = System.Text.Encoding.Default.GetString(texport_player_name);

            return player_name.TrimEnd(chars_to_trim);
        }

        static string readShirtName(byte[] chunk)
        {
            int shirtsize = 16;
            byte[] shirtname_hex = new byte[shirtsize];
            string shirtname = null;

            Array.Copy(chunk, 0x62, shirtname_hex, 0, shirtsize);

            shirtname = System.Text.Encoding.Default.GetString(shirtname_hex);

            return shirtname.TrimEnd(chars_to_trim);
        }

        static string texShirtName(byte[] chunk)
        {
            int max_char = 16;

            byte[] texport_shirt_name = new byte[max_char];

            Array.Copy(chunk, 0x62, texport_shirt_name, 0, max_char);

            string shirt_name = System.Text.Encoding.Default.GetString(texport_shirt_name);

            return shirt_name.TrimEnd(chars_to_trim);
        }

        static int readMainPosition(byte[] chunk)
        {
            // byte 0x20, bits 7-8
            // byte 0x21, bits 1-2

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

            int by20, by21;

            by20 = (chunk[0x20] & 0xC0) >> 6;
            by21 = (chunk[0x21] & 0x03) << 2;
            
            return by20 | by21;
        }

        static int[] readPositionRatings(byte[] chunk)
        {
            int[] rat = new int[13];
            
            // CF - byte 0x26, bits 7-8
            rat[12] = (chunk[0x26] & 0xC0) >> 6;

            // SS - byte 0x27, bits 1-2
            rat[11] = (chunk[0x27] & 0x03);

            // RWF - byte 0x27, bits 5-6
            rat[10] = (chunk[0x27] & 0x30) >> 4;

            // LWF - byte 0x27, bits 3-4
            rat[9] = (chunk[0x27] & 0x0C) >> 2;

            // AMF - byte 0x27, bits 7-8
            rat[8] = (chunk[0x27] & 0xC0) >> 6;

            // RMF - byte 0x28, bits 7-8
            rat[7] = (chunk[0x28] & 0xC0) >> 6;

            // LMF - byte 0x28, bits 5-6
            rat[6] = (chunk[0x28] & 0x30) >> 4;

            // CMF - byte 0x28, bits 3-4
            rat[5] = (chunk[0x28] & 0x0C) >> 2;

            // DMF - byte 0x28, bits 1-2
            rat[4] = (chunk[0x28] & 0x03);

            // RB - byte 0x29, bits 5-6
            rat[3] = (chunk[0x29] & 0x30) >> 4;

            // LB - byte 0x29, bits 3-4
            rat[2] = (chunk[0x29] & 0x0C) >> 2;

            // CB - byte 0x29, bits 1-2
            rat[1] = (chunk[0x29] & 0x03);

            // GK - byte 0x29, bits 7-8
            rat[0] = (chunk[0x29] & 0xC0) >> 6;

            // 0 = C
            // 1 = B
            // 2 = A

            return rat;
        }

        static int readCountry(byte[] chunk)
        {
            // byte 0x0A - 0x0B
            return BitConverter.ToInt16(chunk, 0x0A);
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
            // byte 0x0C
            return chunk[0x0C];
        }

        static int readWeight(byte[] chunk)
        {
            // byte 0x0D
            return chunk[0x0D];
        }

        static int readAge(byte[] chunk)
        {
            // byte 0x20, bits 1-6
            return (chunk[0x20] & 0x3F);
        }

        static int readStrongerFoot(byte[] chunk)
        {
            // byte 0x2E, bit 4
            // 0 = R
            // 1 = L

            return (chunk[0x2E] & 0x08) >> 3;
        }

        static int readAtkProw(byte[] chunk)
        {
            // byte 0x10, bits 1-7
            return chunk[0x10] & 0x7F;
        }

        static int readDribbling(byte[] chunk)
        {
            // byte 0x12, 6-8
            // byte 0x13, 1-4
            int by12, by13;

            by12 = (chunk[0x12] & 0xE0) >> 5;
            by13 = (chunk[0x13] & 0x0F) << 3;

            return by12 | by13;
        }

        static int readBallControl(byte[] chunk)
        {
            // byte 0x22, bits 1-7
            return chunk[0x22] & 0x7F;
        }

        static int readLowPass(byte[] chunk)
        {
            // byte 0x14, bit 8
            // byte 0x15, bits 1-6
            int by14, by15;

            by14 = (chunk[0x14] & 0x80) >> 7;
            by15 = (chunk[0x15] & 0x3F) << 1;

            return by14 | by15;
        }

        static int readLoftedPass(byte[] chunk)
        {
            // byte 0x15, bits 7-8
            // byte 0x16, bits 1-5
            int by15, by16;

            by15 = (chunk[0x15] & 0xC0) >> 6;
            by16 = (chunk[0x16] & 0x1F) << 2;

            return by15 | by16;
        }

        static int readFinishing(byte[] chunk)
        {
            // byte 0x14, bits 1-7

            return (chunk[0x14] & 0x7F);
        }

        static int readPlaceKicking(byte[] chunk)
        {
            // byte 0x2A, 7-8
            // byte 0x2B, 1-5
            int by2A, by2B;

            by2A = (chunk[0x2A] & 0xC0) >> 6;
            by2B = (chunk[0x2B] & 0x1F) << 2;

            return by2A | by2B;
        }

        static int readControlledSpin(byte[] chunk)
        {
            // byte 0x18, bits 1-7
            return (chunk[0x18] & 0x7F);
        }

        static int readHeader(byte[] chunk)
        {
            // byte 0x16, bits 6-8
            // byte 0x17, bits 1-4
            int by16, by17;

            by16 = (chunk[0x16] & 0xE0) >> 5;
            by17 = (chunk[0x17] & 0x0F) << 3;

            return by16 | by17;
        }

        static int readDefProw(byte[] chunk)
        {
            // byte 0x10, bit 8
            // byte 0x11, bits 1-6
            int by10, by11;

            by10 = (chunk[0x10] & 0x80) >> 7;
            by11 = (chunk[0x11] & 0x3F) << 1;

            return by10 | by11;
        }

        static int readBallWinning(byte[] chunk)
        {
            // byte 0x22, bit 8
            // byte 0x23, bits 1-6
            int by22, by23;

            by22 = (chunk[0x22] & 0x80) >> 7;
            by23 = (chunk[0x23] & 0x3F) << 1;

            return by22 | by23;
        }

        static int readKickingPower(byte[] chunk)
        {
            // byte 0x1D, bits 7-8
            // byte 0x1E, bits 1-5
            int by1d, by1e;

            by1d = (chunk[0x1D] & 0xC0) >> 6;
            by1e = (chunk[0x1E] & 0x1F) << 2;

            return by1d | by1e;
        }

        static int readSpeed(byte[] chunk)
        {
            // byte 0x2C, bit 8
            // byte 0x2D, bits 1-6
            int by2c, by2d;

            by2c = (chunk[0x2C] & 0x80) >> 7;
            by2d = (chunk[0x2D] & 0x3F) << 1;

            return by2c | by2d;
        }

        static int readExplosivePower(byte[] chunk)
        {
            // byte 0x1E, bits 6-8
            // byte 0x1F, bits 1-4
            int by1e, by1f;

            by1e = (chunk[0x1E] & 0xE0) >> 5;
            by1f = (chunk[0x1F] & 0x0F) << 3;

            return by1e | by1f;
        }

        static int readBodyBalance(byte[] chunk)
        {
            // byte 0x1C, bits 1-7
            return (chunk[0x1C] & 0x7F);
        }

        static int readPhysicalContact(byte[] chunk)
        {
            // byte 0x1C, bit 8
            // byte 0x1D, bits 1-6
            int by1c, by1d;

            by1c = (chunk[0x1C] & 0x80) >> 7;
            by1d = (chunk[0x1D] & 0x3F) << 1;

            return by1c | by1d;
        }

        static int readJump(byte[] chunk)
        {
            // byte 0x24, bits 1-7
            return (chunk[0x24] & 0x7F);
        }

        static int readGoalkeeping(byte[] chunk)
        {
            // byte 0x11, bits 7-8
            // byte 0x12, bits 1-5
            int by11, by12;

            by11 = (chunk[0x11] & 0xC0) >> 6;
            by12 = (chunk[0x12] & 0x1F) << 2;

            return by11 | by12;
        }

        static int readSaving(byte[] chunk)
        {
            // Catching in PES16
            // byte 0x18, bit 8
            // byte 0x19, bits 1-6
            int by18, by19;

            by18 = (chunk[0x18] & 0x80) >> 7;
            by19 = (chunk[0x19] & 0x3F) << 1;

            return by18 | by19;
        }

        static int readStamina(byte[] chunk)
        {
            // byte 0x2C, bits 1-7
            return (chunk[0x2C] & 0x7F);
        }

        static int readClearing(byte[] chunk)
        {
            // byte 0x19, bits 7-8
            // byte 0x1A, bits 1-5
            int by19, by1a;

            by19 = (chunk[0x19] & 0xC0) >> 6;
            by1a = (chunk[0x1A] & 0x1F) << 2;

            return by19 | by1a;
        }

        static int readReflexes(byte[] chunk)
        {
            // byte 0x1A, bits 6-8
            // byte 0x1B, bits 1-4
            int by1a, by1b;

            by1a = (chunk[0x1A] & 0xE0) >> 5;
            by1b = (chunk[0x1B] & 0x0F) << 3;

            return by1a | by1b;
        }

        static int readCoverage(byte[] chunk)
        {
            // byte 0x25, bits 6-8
            // byte 0x26, bits 1-4
            int by25, by26;

            by25 = (chunk[0x25] & 0xE0) >> 5;
            by26 = (chunk[0x26] & 0x0F) << 3;

            return by25 | by26;
        }

        static int readForm(byte[] chunk)
        {
            // byte 0x17, bits 5-7, plus 1
            return ((chunk[0x17] & 0x70) >> 4) + 1;
        }

        static int readInjuryTol(byte[] chunk)
        {
            // byte 0x1B, bits 5-6
            return ((chunk[0x1B] & 0x30) >> 4) + 1;
        }

        static int readWeakFootUsage(byte[] chunk)
        {
            // byte 0x26, bits 5-6
            return ((chunk[0x26] & 0x30) >> 4) + 1;
        }

        static int readWeakFootAccuracy(byte[] chunk)
        {
            // byte 0x23, bits 7-8
            return ((chunk[0x23] & 0xC0) >> 6) + 1;
        }

        static int readPlayerStyle(byte[] chunk)
        {
            // byte 0x21, bits 4-8

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

            return (chunk[0x21] & 0xF0) >> 4;
        }

        static int[] readCardsPlayStyles(byte[] chunk)
        {
            // byte 0x2E, bits 6-8
            // byte 0x2F, bits 1-4
            int[] cards = new int[7];

            // by2e = 321xxxxx
            // by2f = xxxx7654

            cards[0] = (chunk[0x2E] & 0x20) >> 5;
            cards[1] = (chunk[0x2E] & 0x40) >> 6;
            cards[2] = (chunk[0x2E] & 0x80) >> 7;
            cards[3] = (chunk[0x2F] & 0x01);
            cards[4] = (chunk[0x2F] & 0x02) >> 1;
            cards[5] = (chunk[0x2F] & 0x04) >> 2;
            cards[6] = (chunk[0x2F] & 0x08) >> 3;

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
            int[] cards = new int[28];

            // by2f = 4321xxxx
            // by30 = 21098765
            // by31 = 09876543
            // by32 = 87654321       

            cards[0]  = (chunk[0x2F] & 0x10) >> 4;
            cards[1]  = (chunk[0x2F] & 0x20) >> 5;
            cards[2]  = (chunk[0x2F] & 0x40) >> 6;
            cards[3]  = (chunk[0x2F] & 0x80) >> 7;
            cards[4]  = (chunk[0x30] & 0x01);
            cards[5]  = (chunk[0x30] & 0x02) >> 1;
            cards[6]  = (chunk[0x30] & 0x04) >> 2;
            cards[7]  = (chunk[0x30] & 0x08) >> 3;
            cards[8]  = (chunk[0x30] & 0x10) >> 4;
            cards[9]  = (chunk[0x30] & 0x20) >> 5;
            cards[10] = (chunk[0x30] & 0x40) >> 6;
            cards[11] = (chunk[0x30] & 0x80) >> 7;
            cards[12] = (chunk[0x31] & 0x01);
            cards[13] = (chunk[0x31] & 0x02) >> 1;
            cards[14] = (chunk[0x31] & 0x04) >> 2;
            cards[15] = (chunk[0x31] & 0x08) >> 3;
            cards[16] = (chunk[0x31] & 0x10) >> 4;
            cards[17] = (chunk[0x31] & 0x20) >> 5;
            cards[18] = (chunk[0x31] & 0x40) >> 6;
            cards[19] = (chunk[0x31] & 0x80) >> 7;
            cards[20] = (chunk[0x32] & 0x01);
            cards[21] = (chunk[0x32] & 0x02) >> 1;
            cards[22] = (chunk[0x32] & 0x04) >> 2;
            cards[23] = (chunk[0x32] & 0x08) >> 3;
            cards[24] = (chunk[0x32] & 0x10) >> 4;
            cards[25] = (chunk[0x32] & 0x20) >> 5;
            cards[26] = (chunk[0x32] & 0x40) >> 6;
            cards[27] = (chunk[0x32] & 0x80) >> 7;

            // 1 = Yes, 0 = No
            // [0] = Scissors Feint
            // [1] = Flip Flap
            // [2] = Marseille Turn
            // [3] = Sombrero
            // [4] = Cut Behind Turn
            // [5] = Scotch Move
            // [6] = Heading
            // [7] = Long Range Drive
            // [8] = Knuckle Shot
            // [9] = Acrobatic Finishing
            // [10] = Heel Trick
            // [11] = First Time Shot
            // [12] = One Touch Pass
            // [13] = Weighted Pass
            // [14] = Pinpoint Crossing
            // [15] = Outside Curler
            // [16] = Rabona
            // [17] = Low Lofted Pass
            // [18] = Low Punt Trajectory
            // [19] = Long Throw
            // [20] = GK Long Throw
            // [21] = Malicia
            // [22] = Man Marking
            // [23] = Track Back
            // [24] = Acrobatic Clear
            // [25] = Captaincy
            // [26] = Super Sub
            // [27] = Fighting Spirit

            return cards;
        }

        static int readCommentaryName(byte[] chunk)
        {
            byte[] commentary_hex = new byte[4];
            int commentary = 0;

            Array.Copy(chunk, 4, commentary_hex, 0, 4);
            commentary = BitConverter.ToInt32(commentary_hex, 0);

            return commentary;
        }

        static int readAniCelebration1(byte[] chunk)
        {
            // byte 0x0E
            return chunk[0x0E];
        }

        static int readAniCelebration2(byte[] chunk)
        {
            // byte 0x0F
            return chunk[0x0F];
        }

        static int readAniFreeKick(byte[] chunk)
        {
            // byte 0x13, bits 5-8
            return (((chunk[0x13] & 0xF0) >> 4) + 1);
        }

        static int readAniCornerKick(byte[] chunk)
        {
            // byte 0x25, bits 3-5
            return (((chunk[0x25] & 0x1C) >> 2) + 1);
        }

        static int readAniPenaltyKick(byte[] chunk)
        {
            // byte 0x2A, bits 5-6
            return (((chunk[0x2A] & 0x30) >> 4) + 1);
        }

        static int readAniArmsDribbling(byte[] chunk)
        {
            // byte 0x1F, bits 5-7
            return (((chunk[0x1F] & 0x70) >> 4) + 1);
        }

        static int readAniArmsRunning(byte[] chunk)
        {
            // byte 0x24, bit 8
            // byte 0x25, bits 1-2
            int by24, by25;

            by24 = ((chunk[0x24] & 0x80) >> 7);
            by25 = (chunk[0x25] & 0x03);

            return (by24 | by25) + 1;
        }

        static int readAniHunchDribbling(byte[] chunk)
        {
            // byte 0x2A, bits 1-2
            return ((chunk[0x2A] & 0x03) + 1);
        }

        static int readAniHunchRunning(byte[] chunk)
        {
            // byte 0x2A, bits 3-4
            return (((chunk[0x2A] & 0x0C) >> 2) + 1);
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
            texport = pesXDecrypter.decryptFile(raw_texport);

            // Go 65772 bytes in to get the team name
            int team_name_offset = 0x100ec;

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
            int team_ID_offset = 0x10054;
            byte[] texport_team_ID = new byte[2];

            Array.Copy(texport, team_ID_offset, texport_team_ID, 0, 2);

            squad.teamID = BitConverter.ToInt16(texport_team_ID, 0);

            // Go to the first player in the export
            int player1_offset = 0x510840;

            // Set the pointer
            pointer = player1_offset;
            
            // Loop through all the players
            while (true)
            {
                // Now we have a pointer to the start of the first player
                int chunk_size = 188;
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
                line.Physical_Contact = readPhysicalContact(chunk);
                line.Jump = readJump(chunk);
                line.Goalkeeping = readGoalkeeping(chunk);
                line.Saving = readSaving(chunk);
                line.Stamina = readStamina(chunk);
                line.Clearing = readClearing(chunk);
                line.Reflexes = readReflexes(chunk);
                line.Coverage = readCoverage(chunk);

                line.Form = readForm(chunk);
                line.Injury_Resistance = readInjuryTol(chunk);
                line.Weak_Foot_Usage = readWeakFootUsage(chunk);
                line.Weak_Foot_Accuracy = readWeakFootAccuracy(chunk);
                line.playing_style = readPlayerStyle(chunk);
                line.Cards_Style = readCardsPlayStyles(chunk);
                line.Cards_Skills = readCardsPlaySkills(chunk);

                // Aethetics
                line.commentary_name = readCommentaryName(chunk);
                line.ani_celebration_1 = readAniCelebration1(chunk);
                line.ani_celebration_2 = readAniCelebration2(chunk);
                line.ani_free_kick = readAniFreeKick(chunk);
                line.ani_corner = readAniCornerKick(chunk);
                line.ani_penalty = readAniPenaltyKick(chunk);
                line.ani_arms_dribbling = readAniArmsDribbling(chunk);
                line.ani_arms_running = readAniArmsRunning(chunk);
                line.ani_hunch_dribbling = readAniHunchDribbling(chunk);
                line.ani_hunch_running = readAniHunchRunning(chunk);

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
            ebin = pesXDecrypter.decryptFile(raw_ebin);

            List<player> player_table = new List<player>();
            Hashtable team_table = new Hashtable();
            Hashtable teams_4cc = new Hashtable();

            // Setup teams
            teams_4cc = Lookup.setup_teams_4cc();
            team_table = import_team_table(ebin, teams_4cc);

            // Jump to 120 bytes in
            pointer = 120;

            while (true)
            {
                // Now we have a pointer to the start of the first player
                // Grab the next 116 bytes
                int size_of_player = 116;

                // PES17 now combines the aesthetics into the player table, grab that too
                size_of_player += 72;

                byte[] chunk = new byte[size_of_player];
                Array.Copy(ebin, pointer, chunk, 0, size_of_player);

                // Set the new pointer for the next iteration
                pointer += size_of_player;

                // Create a new Player
                player line = new player();

                // Read PlayerID
                line.id = readPlayerID(chunk);
                line.name = readPlayerName(chunk);
                line.shirt_name = readShirtName(chunk);

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
                    line.Physical_Contact = readPhysicalContact(chunk);
                    line.Jump = readJump(chunk);
                    line.Goalkeeping = readGoalkeeping(chunk);
                    line.Saving = readSaving(chunk);
                    line.Stamina = readStamina(chunk);
                    line.Clearing = readClearing(chunk);
                    line.Reflexes = readReflexes(chunk);
                    line.Coverage = readCoverage(chunk);

                    line.Form = readForm(chunk);
                    line.Injury_Resistance = readInjuryTol(chunk);
                    line.Weak_Foot_Usage = readWeakFootUsage(chunk);
                    line.Weak_Foot_Accuracy = readWeakFootAccuracy(chunk);
                    line.playing_style = readPlayerStyle(chunk);
                    line.Cards_Style = readCardsPlayStyles(chunk);
                    line.Cards_Skills = readCardsPlaySkills(chunk);

                    // Aethetics
                    line.commentary_name = readCommentaryName(chunk);
                    line.ani_celebration_1 = readAniCelebration1(chunk);
                    line.ani_celebration_2 = readAniCelebration2(chunk);
                    line.ani_free_kick = readAniFreeKick(chunk);
                    line.ani_corner = readAniCornerKick(chunk);
                    line.ani_penalty = readAniPenaltyKick(chunk);
                    line.ani_arms_dribbling = readAniArmsDribbling(chunk);
                    line.ani_arms_running = readAniArmsRunning(chunk);
                    line.ani_hunch_dribbling = readAniHunchDribbling(chunk);
                    line.ani_hunch_running = readAniHunchRunning(chunk);

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

            if (bin_length < 5600000)
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
            int offset_team1 = 0x475A90;

            pointer = offset_team1;

            while (true)
            {
                // Now we have a pointer to the start of the team
                // Grab the next 164 bytes
                int size_of_team = 164;

                byte[] chunk = new byte[size_of_team];
                Array.Copy(ebin, pointer, chunk, 0, size_of_team);

                // TeamID is the first 4 bytes
                int teamID = BitConverter.ToInt32(chunk, 0);

                if (teamID >= 1010)
                {
                    // Reached end of the team table
                    break;
                }

                if (teams_4cc.ContainsKey(teamID))
                {
                    // Valid 4cc team
                    int playerID;
                    int pos = 4;

                    while (true)
                    {
                        playerID = BitConverter.ToInt32(chunk, pos);

                        if (playerID <= 0)
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
