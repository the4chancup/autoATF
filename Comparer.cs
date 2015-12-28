using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace AATF_15
{
    class comparer
    {
        private static int current_player_id;
        private static string current_player_name;

        public static int get_compare_type()
        {
            int type = -1; // 0 - Save/Save, 1 - Save/Export, 2 - Export/Save, 3 - Export/Export, -1 - ERROR

            if (Importer.is_edit_bin(switches.input_file))
            {
                // File 1 is a save

                if (Importer.is_edit_bin(switches.compare_file))
                {
                    // File 2 is a save
                    // Save/Save
                    type = 0;
                }
                else
                {
                    // File 2 is an export
                    // Save/Export
                    type = 1;
                }
            }
            else
            {
                // File 1 is an export

                if (Importer.is_edit_bin(switches.compare_file))
                {
                    // File 2 is a save
                    // Export/Save
                    type = 2;
                }
                else
                {
                    // File 2 is an export
                    // Export/Export
                    type = 3;
                }
            }

            return type;
        }

        public static void compare_teams(team squad_1, team squad_2)
        {
            foreach (player player_1 in squad_1.team_players)
            {
                foreach (player player_2 in squad_2.team_players)
                {
                    if (player_1.id == player_2.id)
                    {
                        int i;

                        current_player_id = player_1.id;
                        current_player_name = player_1.name;

                        Console.WriteLine("* Comparing " + current_player_name);

                        // Compare the player in either file
                        compare_value(player_1.nationality, player_2.nationality, "nationality");
                        compare_value(player_1.position, player_2.position, "position");

                        for (i = 0; i < 13; i++)
                        {
                            compare_value(player_1.PosRats[i], player_2.PosRats[i], "position_ratings");
                        }

                        compare_value(player_1.height, player_2.height, "height");
                        compare_value(player_1.weight, player_2.weight, "weight");
                        compare_value(player_1.age, player_2.age, "age");
                        compare_value(player_1.stronger_foot, player_2.stronger_foot, "stronger_foot");

                        compare_value(player_1.Attacking_Prowess, player_2.Attacking_Prowess, "Attacking_Prowess");
                        compare_value(player_1.Ball_Control, player_2.Ball_Control, "Ball_Control");
                        compare_value(player_1.Dribbling, player_2.Dribbling, "Dribbling");
                        compare_value(player_1.Low_Pass, player_2.Low_Pass, "Low_Pass");
                        compare_value(player_1.Lofted_Pass, player_2.Lofted_Pass, "Lofted_Pass");
                        compare_value(player_1.Finishing, player_2.Finishing, "Finishing");
                        compare_value(player_1.Place_Kicking, player_2.Place_Kicking, "Place_Kicking");
                        compare_value(player_1.Controlled_Spin, player_2.Controlled_Spin, "Controlled_Spin");
                        compare_value(player_1.Header, player_2.Header, "Header");
                        compare_value(player_1.Defensive_Prowess, player_2.Defensive_Prowess, "Defensive_Prowess");
                        compare_value(player_1.Ball_Winning, player_2.Ball_Winning, "Ball_Winning");
                        compare_value(player_1.Kicking_Power, player_2.Kicking_Power, "Kicking_Power");
                        compare_value(player_1.Speed, player_2.Speed, "Speed");
                        compare_value(player_1.Explosive_Power, player_2.Explosive_Power, "Explosive_Power");
                        compare_value(player_1.Body_Balance, player_2.Body_Balance, "Body_Balance");
                        compare_value(player_1.Jump, player_2.Jump, "Jump");
                        compare_value(player_1.Goalkeeping, player_2.Goalkeeping, "Goalkeeping");
                        compare_value(player_1.Saving, player_2.Saving, "Saving");
                        compare_value(player_1.Stamina, player_2.Stamina, "Stamina");
                        compare_value(player_1.Form, player_2.Form, "Form");
                        compare_value(player_1.Clearing, player_2.Clearing, "Clearing");
                        compare_value(player_1.Reflexes, player_2.Reflexes, "Reflexes");
                        compare_value(player_1.Coverage, player_2.Coverage, "Coverage");

                        compare_value(player_1.Injury_Resistance, player_2.Injury_Resistance, "Injury_Resistance");

                        compare_value(player_1.Weak_Foot_Accuracy, player_2.Weak_Foot_Accuracy, "Weak_Foot_Accuracy");
                        compare_value(player_1.Weak_Foot_Usage, player_2.Weak_Foot_Usage, "Weak_Foot_Usage");

                        compare_value(player_1.playing_style, player_2.playing_style, "playing_style");

                        for (i = 0; i < 7; i++)
                        {
                            compare_value(player_1.Cards_Style[i], player_2.Cards_Style[i], "Style_Cards");
                        }

                        for (i = 0; i < 28; i++)
                        {
                            compare_value(player_1.Cards_Skills[i], player_2.Cards_Skills[i], "Skill_Cards");
                        }

                        // Aesthetics - not illegal to change these but might as well check anyway
                        compare_value(player_1.commentary_name, player_2.commentary_name, "commentary_name");
                        compare_value(player_1.ani_celebration_1, player_2.ani_celebration_1, "Animation: celebration_1");
                        compare_value(player_1.ani_celebration_2, player_2.ani_celebration_2, "Animation: celebration_2");
                        compare_value(player_1.ani_free_kick, player_2.ani_free_kick, "Animation: free_kick");
                        compare_value(player_1.ani_corner, player_2.ani_corner, "Animation: corner");
                        compare_value(player_1.ani_penalty, player_2.ani_penalty, "Animation: penalty");
                        compare_value(player_1.ani_arms_dribbling, player_2.ani_arms_dribbling, "Animation: arms_dribbling");
                        compare_value(player_1.ani_arms_running, player_2.ani_arms_running, "Animation: arms_running");
                        compare_value(player_1.ani_hunch_dribbling, player_2.ani_hunch_dribbling, "Animation: hunch_dribbling");
                        compare_value(player_1.ani_hunch_running, player_2.ani_hunch_running, "Animation: hunch_running");
                    }
                }
            }
        }

        public static void compare_value(int a, int b, string value)
        {
            if (a != b)
            {
                Console.WriteLine(current_player_id + "\t" + current_player_name + "\t" + "has differing " + value);
                variables.errors++;
            }
        }
    }
}