using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATF_test
{
    public class Check_Cards
    {
        public static void check_cards(player line)
        {
            int style_card_count = Program.Count_Bool(line.Trickster,
                                                        line.Mazing_Run,
                                                        line.Speeding_Bullet,
                                                        line.Incisive_Run,
                                                        line.Long_Ball_Expert,
                                                        line.Early_Cross,
                                                        line.Long_Ranger);

            int skill_card_count = Program.Count_Bool(line.Scissors_Feint,
                                                        line.Flip_Flap,
                                                        line.Marseille_Turn,
                                                        line.Sombrero,
                                                        line.Precise_Touch,
                                                        line.Long_Range_Drive,
                                                        line.Knuckle_Shot,
                                                        line.Acrobatic_Finishing,
                                                        line.First_Time_Shot,
                                                        line.One_Touch_Pass,
                                                        line.Weighted_Pass,
                                                        line.Pinpoint_Crossing,
                                                        line.Outside_Curler,
                                                        line.Low_Punt_Trajectory,
                                                        line.Long_Throw,
                                                        line.Man_Marking,
                                                        line.Track_Back,
                                                        line.Super_Sub);

            int total_cards = style_card_count + skill_card_count;
            
            // Set the total cards for this player, for later team-wide card count
            line.cards_sum = total_cards;
            
            if (line.is_regular)
            {
                if (total_cards > constants.cards_limit_regular)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many Cards (Has " + total_cards + ", can only have " + constants.cards_limit_regular + " max)");
                    variables.errors++;
                }
            }
            else if (line.is_silver)
            {
                if (total_cards > constants.cards_limit_silver)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many Cards (Has " + total_cards + ", can only have " + constants.cards_limit_silver + " max)");
                    variables.errors++;
                }
            }
            else if (line.is_gold)
            {
                if (total_cards > constants.cards_limit_gold)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has too many Cards (Has " + total_cards + ", can only have " + constants.cards_limit_gold + " max)");
                    variables.errors++;
                }
            }
            else if (line.is_goalkeeper)
            {
                if(!line.GK_Long_Throw)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " does not have the free GK Long Throw card");
                    variables.errors++;
                }
            }
        }

        public static void check_team_cards(team squad)
        {
            int cards = 0;

            foreach (player line in squad.team_players)
            {
                cards += line.cards_sum;
            }

            if (cards > constants.cards_limit_team)
            {
                Console.WriteLine(squad.team_name + " has too many Cards (Has " + cards + ", can only have " + constants.cards_limit_team + " max)");
                variables.errors++;
            }

            if (cards < constants.cards_limit_team)
            {
                Console.WriteLine("NOTE: " + squad.team_name + " is below the card limit (Has " + cards + ", can have up to " + constants.cards_limit_team + " max)");
            }
        }

        public static void check_cards_captaincy(team squad)
        {
            int captaincy = 0;

            foreach (player line in squad.team_players)
            {
                if (line.Captaincy)
                {
                    captaincy++;
                }
            }

            if (captaincy > 1)
            {
                Console.WriteLine(squad.team_name + " has too many Captaincy Cards (Has " + captaincy + ", can only have 1 max)");
                variables.errors++;
            }

            if (captaincy < 1)
            {
                Console.WriteLine(squad.team_name + " Captain has no Captaincy Card");
                variables.errors++;
            }

        }
    }
}
