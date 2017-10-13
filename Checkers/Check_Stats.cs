using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    public class Check_Stats
    {
        public static void check_stats(player line)
        {
            // default to "there is an error in your stats"
            line.statType = 0;
            for (uint i = 0; i < constants.stats.Length; ++i)
            {
                if (line.Goalkeeping == constants.stats[i] &&
                   line.Dribbling == constants.stats[i] &&
                   line.Finishing == constants.stats[i] &&
                   line.Low_Pass == constants.stats[i] &&
                   line.Lofted_Pass == constants.stats[i] &&
                   line.Header == constants.stats[i] &&
                   line.Controlled_Spin == constants.stats[i] &&
                   line.Saving == constants.stats[i] &&
                   line.Clearing == constants.stats[i] &&
                   line.Reflexes == constants.stats[i] &&
                   line.Body_Balance == constants.stats[i] &&
                   line.Physical_Contact == constants.stats[i] &&
                   line.Kicking_Power == constants.stats[i] &&
                   line.Explosive_Power == constants.stats[i] &&
                   line.Jump == constants.stats[i] &&
                   line.Ball_Control == constants.stats[i] &&
                   line.Ball_Winning == constants.stats[i] &&
                   line.Coverage == constants.stats[i] &&
                   line.Place_Kicking == constants.stats[i] &&
                   line.Speed == constants.stats[i] &&
                   line.Stamina == constants.stats[i] &&
                   (i == 0 || line.position != 0)) // ensure goalkeepers are on i=0 only
                {
                    line.ptype = i;
                    line.statType = 2;
                }
                else if (line.Goalkeeping == constants.stats_system1[i] &&
                   line.Dribbling == constants.stats_system1[i] &&
                   line.Finishing == constants.stats_system1[i] &&
                   line.Low_Pass == constants.stats_system1[i] &&
                   line.Lofted_Pass == constants.stats_system1[i] &&
                   line.Header == constants.stats_system1[i] &&
                   line.Controlled_Spin == constants.stats_system1[i] &&
                   line.Saving == constants.stats_system1[i] &&
                   line.Clearing == constants.stats_system1[i] &&
                   line.Reflexes == constants.stats_system1[i] &&
                   line.Body_Balance == constants.stats_system1[i] &&
                   line.Physical_Contact == constants.stats_system1[i] &&
                   line.Kicking_Power == constants.stats_system1[i] &&
                   line.Explosive_Power == constants.stats_system1[i] &&
                   line.Jump == constants.stats_system1[i] &&
                   line.Ball_Control == constants.stats_system1[i] &&
                   line.Ball_Winning == constants.stats_system1[i] &&
                   line.Coverage == constants.stats_system1[i] &&
                   line.Place_Kicking == constants.stats_system1[i] &&
                   line.Speed == constants.stats_system1[i] &&
                   line.Stamina == constants.stats_system1[i] &&
                   (i == 0 || line.position != 0)) // goalkeepers must be checked on i=0
                {
                    line.ptype = i;
                    line.statType = 1;
                }
            }

            // If it doesn't match anything after checking all options
            if (line.statType == 0)
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
            if (line.statType == 1) { stats = constants.stats_system1[line.ptype]; }
            else if (line.statType == 2) { stats = constants.stats[line.ptype]; }
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
                if (line.ptype == 3)
                {
                    golds++;
                }

                if (line.ptype == 2)
                {
                    silvers++;
                }
                // count regular and gk players together
                if (line.ptype == 0 || line.ptype == 1)
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
