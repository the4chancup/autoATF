using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF_15
{
    public class Check_Stats
    {
        public static void check_stats(player line)
        {
            // GOLD
            if (line.Goalkeeping == constants.stats_gold &&
               line.Dribbling == constants.stats_gold &&
               line.Finishing == constants.stats_gold &&
               line.Low_Pass == constants.stats_gold &&
               line.Lofted_Pass == constants.stats_gold &&
               line.Header == constants.stats_gold &&
               line.Form == constants.stats_gold &&
               line.Controlled_Spin == constants.stats_gold &&
               line.Saving == constants.stats_gold &&
               line.Clearing == constants.stats_gold &&
               line.Reflexes == constants.stats_gold &&
               line.Body_Balance == constants.stats_gold &&
               line.Kicking_Power == constants.stats_gold &&
               line.Explosive_Power == constants.stats_gold &&
               line.Jump == constants.stats_gold &&
               line.Ball_Control == constants.stats_gold &&
               line.Ball_Winning == constants.stats_gold &&
               line.Coverage == constants.stats_gold &&
               line.Place_Kicking == constants.stats_gold &&
               line.Speed == constants.stats_gold &&
               line.Stamina == constants.stats_gold)
            {
                line.is_gold = true;
            }

            // GOLD SYSTEM 1 --- SUMMER 2015 HEIGHT ABUSE EDITION
            else if (line.Goalkeeping == constants.stats_gold_system1 &&
               line.Dribbling == constants.stats_gold_system1 &&
               line.Finishing == constants.stats_gold_system1 &&
               line.Low_Pass == constants.stats_gold_system1 &&
               line.Lofted_Pass == constants.stats_gold_system1 &&
               line.Header == constants.stats_gold_system1 &&
               line.Form == constants.stats_gold_system1 &&
               line.Controlled_Spin == constants.stats_gold_system1 &&
               line.Saving == constants.stats_gold_system1 &&
               line.Clearing == constants.stats_gold_system1 &&
               line.Reflexes == constants.stats_gold_system1 &&
               line.Body_Balance == constants.stats_gold_system1 &&
               line.Kicking_Power == constants.stats_gold_system1 &&
               line.Explosive_Power == constants.stats_gold_system1 &&
               line.Jump == constants.stats_gold_system1 &&
               line.Ball_Control == constants.stats_gold_system1 &&
               line.Ball_Winning == constants.stats_gold_system1 &&
               line.Coverage == constants.stats_gold_system1 &&
               line.Place_Kicking == constants.stats_gold_system1 &&
               line.Speed == constants.stats_gold_system1 &&
               line.Stamina == constants.stats_gold_system1)
            {
                line.is_gold = true;
                line.is_gold_system1 = true;
            }

           // SILVER
            else if (line.Goalkeeping == constants.stats_silver &&
               line.Dribbling == constants.stats_silver &&
               line.Finishing == constants.stats_silver &&
               line.Low_Pass == constants.stats_silver &&
               line.Lofted_Pass == constants.stats_silver &&
               line.Header == constants.stats_silver &&
               line.Form == constants.stats_silver &&
               line.Controlled_Spin == constants.stats_silver &&
               line.Saving == constants.stats_silver &&
               line.Clearing == constants.stats_silver &&
               line.Reflexes == constants.stats_silver &&
               line.Body_Balance == constants.stats_silver &&
               line.Kicking_Power == constants.stats_silver &&
               line.Explosive_Power == constants.stats_silver &&
               line.Jump == constants.stats_silver &&
               line.Ball_Control == constants.stats_silver &&
               line.Ball_Winning == constants.stats_silver &&
               line.Coverage == constants.stats_silver &&
               line.Place_Kicking == constants.stats_silver &&
               line.Speed == constants.stats_silver &&
               line.Stamina == constants.stats_silver)
            {
                line.is_silver = true;
            }

            // SILVER SYSTEM 1 --- SUMMER 2015 HEIGHT ABUSE EDITION
            else if (line.Goalkeeping == constants.stats_silver_system1 &&
               line.Dribbling == constants.stats_silver_system1 &&
               line.Finishing == constants.stats_silver_system1 &&
               line.Low_Pass == constants.stats_silver_system1 &&
               line.Lofted_Pass == constants.stats_silver_system1 &&
               line.Header == constants.stats_silver_system1 &&
               line.Form == constants.stats_silver_system1 &&
               line.Controlled_Spin == constants.stats_silver_system1 &&
               line.Saving == constants.stats_silver_system1 &&
               line.Clearing == constants.stats_silver_system1 &&
               line.Reflexes == constants.stats_silver_system1 &&
               line.Body_Balance == constants.stats_silver_system1 &&
               line.Kicking_Power == constants.stats_silver_system1 &&
               line.Explosive_Power == constants.stats_silver_system1 &&
               line.Jump == constants.stats_silver_system1 &&
               line.Ball_Control == constants.stats_silver_system1 &&
               line.Ball_Winning == constants.stats_silver_system1 &&
               line.Coverage == constants.stats_silver_system1 &&
               line.Place_Kicking == constants.stats_silver_system1 &&
               line.Speed == constants.stats_silver_system1 &&
               line.Stamina == constants.stats_silver_system1)
            {
                line.is_silver = true;
                line.is_silver_system1 = true;
            }

            // REGULAR
            else if (line.Goalkeeping == constants.stats_regular &&
               line.Dribbling == constants.stats_regular &&
               line.Finishing == constants.stats_regular &&
               line.Low_Pass == constants.stats_regular &&
               line.Lofted_Pass == constants.stats_regular &&
               line.Header == constants.stats_regular &&
               line.Form == constants.stats_regular &&
               line.Controlled_Spin == constants.stats_regular &&
               line.Saving == constants.stats_regular &&
               line.Clearing == constants.stats_regular &&
               line.Reflexes == constants.stats_regular &&
               line.Body_Balance == constants.stats_regular &&
               line.Kicking_Power == constants.stats_regular &&
               line.Explosive_Power == constants.stats_regular &&
               line.Jump == constants.stats_regular &&
               line.Ball_Control == constants.stats_regular &&
               line.Ball_Winning == constants.stats_regular &&
               line.Coverage == constants.stats_regular &&
               line.Place_Kicking == constants.stats_regular &&
               line.Speed == constants.stats_regular &&
               line.Stamina == constants.stats_regular)
            {
                line.is_regular = true;
            }

            // REGULAR SYSTEM 1 --- SUMMER 2015 HEIGHT ABUSE EDITION
            else if (line.Goalkeeping == constants.stats_regular_system1 &&
               line.Dribbling == constants.stats_regular_system1 &&
               line.Finishing == constants.stats_regular_system1 &&
               line.Low_Pass == constants.stats_regular_system1 &&
               line.Lofted_Pass == constants.stats_regular_system1 &&
               line.Header == constants.stats_regular_system1 &&
               line.Form == constants.stats_regular_system1 &&
               line.Controlled_Spin == constants.stats_regular_system1 &&
               line.Saving == constants.stats_regular_system1 &&
               line.Clearing == constants.stats_regular_system1 &&
               line.Reflexes == constants.stats_regular_system1 &&
               line.Body_Balance == constants.stats_regular_system1 &&
               line.Kicking_Power == constants.stats_regular_system1 &&
               line.Explosive_Power == constants.stats_regular_system1 &&
               line.Jump == constants.stats_regular_system1 &&
               line.Ball_Control == constants.stats_regular_system1 &&
               line.Ball_Winning == constants.stats_regular_system1 &&
               line.Coverage == constants.stats_regular_system1 &&
               line.Place_Kicking == constants.stats_regular_system1 &&
               line.Speed == constants.stats_regular_system1 &&
               line.Stamina == constants.stats_regular_system1)
            {
                line.is_regular = true;
                line.is_regular_system1 = true;
            }

            // GK
            else if (line.Goalkeeping == constants.stats_goalkeeper &&
               line.Dribbling == constants.stats_goalkeeper &&
               line.Finishing == constants.stats_goalkeeper &&
               line.Low_Pass == constants.stats_goalkeeper &&
               line.Lofted_Pass == constants.stats_goalkeeper &&
               line.Header == constants.stats_goalkeeper &&
               line.Form == constants.stats_goalkeeper &&
               line.Controlled_Spin == constants.stats_goalkeeper &&
               line.Saving == constants.stats_goalkeeper &&
               line.Clearing == constants.stats_goalkeeper &&
               line.Reflexes == constants.stats_goalkeeper &&
               line.Body_Balance == constants.stats_goalkeeper &&
               line.Kicking_Power == constants.stats_goalkeeper &&
               line.Explosive_Power == constants.stats_goalkeeper &&
               line.Jump == constants.stats_goalkeeper &&
               line.Ball_Control == constants.stats_goalkeeper &&
               line.Ball_Winning == constants.stats_goalkeeper &&
               line.Coverage == constants.stats_goalkeeper &&
               line.Place_Kicking == constants.stats_goalkeeper &&
               line.Speed == constants.stats_goalkeeper &&
               line.Stamina == constants.stats_goalkeeper)
            {
                line.is_goalkeeper = true;
            }

            // GOALKEEPER SYSTEM 1 --- SUMMER 2015 HEIGHT ABUSE EDITION
            else if (line.Goalkeeping == constants.stats_goalkeeper_system1 &&
               line.Dribbling == constants.stats_goalkeeper_system1 &&
               line.Finishing == constants.stats_goalkeeper_system1 &&
               line.Low_Pass == constants.stats_goalkeeper_system1 &&
               line.Lofted_Pass == constants.stats_goalkeeper_system1 &&
               line.Header == constants.stats_goalkeeper_system1 &&
               line.Form == constants.stats_goalkeeper_system1 &&
               line.Controlled_Spin == constants.stats_goalkeeper_system1 &&
               line.Saving == constants.stats_goalkeeper_system1 &&
               line.Clearing == constants.stats_goalkeeper_system1 &&
               line.Reflexes == constants.stats_goalkeeper_system1 &&
               line.Body_Balance == constants.stats_goalkeeper_system1 &&
               line.Kicking_Power == constants.stats_goalkeeper_system1 &&
               line.Explosive_Power == constants.stats_goalkeeper_system1 &&
               line.Jump == constants.stats_goalkeeper_system1 &&
               line.Ball_Control == constants.stats_goalkeeper_system1 &&
               line.Ball_Winning == constants.stats_goalkeeper_system1 &&
               line.Coverage == constants.stats_goalkeeper_system1 &&
               line.Place_Kicking == constants.stats_goalkeeper_system1 &&
               line.Speed == constants.stats_goalkeeper_system1 &&
               line.Stamina == constants.stats_goalkeeper_system1)
            {
                line.is_goalkeeper = true;
                line.is_goalkeeper_system1 = true;
            }

            // If it doesn't match anything
            else
            {
                Console.WriteLine(line.id + "\t" + line.name + " has invalid stats");
                variables.errors++;
            }
        }

        public static void check_prowess(player line)
        {
            uint stats = 0U;

            // Prowess can be set to any value, but cannot exceed the medal stat for that player
            // Lets get the medal stat for that player, then compare it to their Att/Def Prowess
            if (line.is_gold)
            {
                stats = constants.stats_gold;
            }
            else if (line.is_gold_system1)
            {
                stats = constants.stats_gold_system1;
            }
            else if (line.is_silver)
            {
                stats = constants.stats_silver;
            }
            else if (line.is_silver_system1)
            {
                stats = constants.stats_silver_system1;
            }
            else if (line.is_regular)
            {
                stats = constants.stats_regular;
            }
            else if (line.is_regular_system1)
            {
                stats = constants.stats_regular_system1;
            }
            else if (line.is_goalkeeper)
            {
                stats = constants.stats_goalkeeper;
            }
            else if (line.is_goalkeeper_system1)
            {
                stats = constants.stats_goalkeeper_system1;
            }
            else
            {
                // Player has invalid stats, disregard Prowess check
                Console.WriteLine(line.id + "\t" + line.name + " has invalid stats, so Prowess cannot be checked");
                variables.errors++;
            }

            if (stats > 0)
            {
                if (line.Attacking_Prowess > stats)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has invalid Attacking Prowess (Is " + line.Attacking_Prowess + ", should be " + stats + ")");
                    variables.errors++;
                }

                if (line.Defensive_Prowess > stats)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has invalid Defensive Prowess (Is " + line.Defensive_Prowess + ", should be " + stats + ")");
                    variables.errors++;
                }
            }
        }

        public static void check_ggss(team squad)
        {
            uint golds = 0;
            uint silvers = 0;
            uint regulars = 0;

            foreach (player line in squad.team_players)
            {
                if (line.is_gold)
                {
                    golds++;
                }

                if (line.is_silver)
                {
                    silvers++;
                }

                if (line.is_regular)
                {
                    regulars++;
                }
                /*
                if(line.is_goalkeeper)
                {
                    regulars++;
                }*/
            }

            // GOLDS
            if (golds > constants.players_gold)
            {
                Console.WriteLine(squad.team_name + " has too many Gold Players (Has " + golds + ", should have " + constants.players_gold + ")");
                variables.errors++;
            }

            if (golds < constants.players_gold)
            {
                Console.WriteLine(squad.team_name + " has too few Gold Players (Has " + golds + ", should have " + constants.players_gold + ")");
                variables.errors++;
            }

            // SILVERS
            if (silvers > constants.players_silver)
            {
                Console.WriteLine(squad.team_name + " has too many Silver Players (Has " + silvers + ", should have " + constants.players_silver + ")");
                variables.errors++;
            }

            if (silvers < constants.players_silver)
            {
                Console.WriteLine(squad.team_name + " has too few Silver Players (Has " + silvers + ", should have " + constants.players_silver + ")");
                variables.errors++;
            }

            // REGULARS AND GOALKEEPERS
            if (regulars > constants.players_regular_and_gk)
            {
                Console.WriteLine(squad.team_name + " has too many Non-Medal Players (Has " + regulars + ", should have " + constants.players_regular_and_gk + ")");
                variables.errors++;
            }

            if (regulars < constants.players_regular_and_gk)
            {
                Console.WriteLine(squad.team_name + " has too few Non-Medal Players (Has " + regulars + ", should have " + constants.players_regular_and_gk + ")");
                variables.errors++;
            }
        }
    }
}
