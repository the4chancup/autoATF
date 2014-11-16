using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATF_test
{
    public class Check_Stats
    {
        public static void check_stats(player line)
        {            
            // GOLD
            if (line.Attacking_Prowess == constants.stats_gold &
               line.Ball_Control == constants.stats_gold &
               line.Dribbling == constants.stats_gold &
               line.Low_Pass == constants.stats_gold &
               line.Lofted_Pass == constants.stats_gold &
               line.Finishing == constants.stats_gold &
               line.Place_Kicking == constants.stats_gold &
               line.Controlled_Spin == constants.stats_gold &
               line.Header == constants.stats_gold &
               line.Defensive_Prowess == constants.stats_gold &
               line.Ball_Winning == constants.stats_gold &
               line.Kicking_Power == constants.stats_gold &
               line.Speed == constants.stats_gold &
               line.Explosive_Power == constants.stats_gold &
               line.Body_Balance == constants.stats_gold &
               line.Jump == constants.stats_gold &
               line.Goalkeeping == constants.stats_gold &
               line.Saving == constants.stats_gold &
               line.Tenacity == constants.stats_gold &
               line.Stamina == constants.stats_gold)
            {
                line.is_gold = true;
            }

           // SILVER
            else if (line.Attacking_Prowess == constants.stats_silver &
                line.Ball_Control == constants.stats_silver &
                line.Dribbling == constants.stats_silver &
                line.Low_Pass == constants.stats_silver &
                line.Lofted_Pass == constants.stats_silver &
                line.Finishing == constants.stats_silver &
                line.Place_Kicking == constants.stats_silver &
                line.Controlled_Spin == constants.stats_silver &
                line.Header == constants.stats_silver &
                line.Defensive_Prowess == constants.stats_silver &
                line.Ball_Winning == constants.stats_silver &
                line.Kicking_Power == constants.stats_silver &
                line.Speed == constants.stats_silver &
                line.Explosive_Power == constants.stats_silver &
                line.Body_Balance == constants.stats_silver &
                line.Jump == constants.stats_silver &
                line.Goalkeeping == constants.stats_silver &
                line.Saving == constants.stats_silver &
                line.Tenacity == constants.stats_silver &
                line.Stamina == constants.stats_silver)
            {
                line.is_silver = true;
            }

            // REGULAR
            else if (line.Attacking_Prowess == constants.stats_regular &
                line.Ball_Control == constants.stats_regular &
                line.Dribbling == constants.stats_regular &
                line.Low_Pass == constants.stats_regular &
                line.Lofted_Pass == constants.stats_regular &
                line.Finishing == constants.stats_regular &
                line.Place_Kicking == constants.stats_regular &
                line.Controlled_Spin == constants.stats_regular &
                line.Header == constants.stats_regular &
                line.Defensive_Prowess == constants.stats_regular &    // Defensive Prowess is 88 on regulars ----- Doesnt seem to be the case for Autumn 2014
                line.Ball_Winning == constants.stats_regular &
                line.Kicking_Power == constants.stats_regular &
                line.Speed == constants.stats_regular &
                line.Explosive_Power == constants.stats_regular &
                line.Body_Balance == constants.stats_regular &
                line.Jump == constants.stats_regular &
                line.Goalkeeping == constants.stats_regular &
                line.Saving == constants.stats_regular &
                line.Tenacity == constants.stats_regular &
                line.Stamina == constants.stats_regular)
            {
                line.is_regular = true;
            }

            // GK
            else if (line.Attacking_Prowess == constants.stats_goalkeeper &
                line.Ball_Control == constants.stats_goalkeeper &
                line.Dribbling == constants.stats_goalkeeper &
                line.Low_Pass == constants.stats_goalkeeper &
                line.Lofted_Pass == constants.stats_goalkeeper &
                line.Finishing == constants.stats_goalkeeper &
                line.Place_Kicking == constants.stats_goalkeeper &
                line.Controlled_Spin == constants.stats_goalkeeper &
                line.Header == constants.stats_goalkeeper &
                line.Defensive_Prowess == constants.stats_goalkeeper &  // Goalkeepers have 99 defensive prowess ----- Doesnt seem to be the case for Autumn 2014
                line.Ball_Winning == constants.stats_goalkeeper &
                line.Kicking_Power == constants.stats_goalkeeper &
                line.Speed == constants.stats_goalkeeper &
                line.Explosive_Power == constants.stats_goalkeeper &
                line.Body_Balance == constants.stats_goalkeeper &
                line.Jump == constants.stats_goalkeeper &                // Goalkeepers have 66 jump/goalkeeping/saving ----- Doesnt seem to be the case for Autumn 2014
                line.Goalkeeping == constants.stats_goalkeeper &                // Goalkeepers have 66 jump/goalkeeping/saving ----- Doesnt seem to be the case for Autumn 2014
                line.Saving == constants.stats_goalkeeper &                // Goalkeepers have 66 jump/goalkeeping/saving ----- Doesnt seem to be the case for Autumn 2014
                line.Tenacity == constants.stats_goalkeeper &
                line.Stamina == constants.stats_goalkeeper)
            {
                line.is_goalkeeper = true;
            }

            else
            {
                Console.WriteLine(line.id + "\t" + line.name + " has invalid stats");
                variables.errors++;
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
                
                if(line.is_goalkeeper)
                {
                    regulars++;
                }
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
