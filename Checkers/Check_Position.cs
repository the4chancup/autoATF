using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATF_test
{
    public class Check_Position
    {
        public static bool Position_Rationalise(player line, string position)
        {
            if (position.Equals("A"))
            {
                return true;
            }
            else if (position.Equals("C"))
            {
                return false;
            }
            else
            {
                Console.WriteLine(line.id + "\t" + line.name + " has an invalid rating in a position");
                variables.errors++;
                return false;
            }
        }

        public static void check_player_positions(player line)
        {
            // Rationalise the positions to boolean (A rating = true, C rating = false, anything else triggers an error)
            line.position_gk = Position_Rationalise(line, line.gk);
            line.position_cb = Position_Rationalise(line, line.cb);
            line.position_lb = Position_Rationalise(line, line.lb);
            line.position_rb = Position_Rationalise(line, line.rb);
            line.position_dmf = Position_Rationalise(line, line.dmf);
            line.position_cmf = Position_Rationalise(line, line.cmf);
            line.position_lmf = Position_Rationalise(line, line.lmf);
            line.position_rmf = Position_Rationalise(line, line.rmf);
            line.position_amf = Position_Rationalise(line, line.amf);
            line.position_lwf = Position_Rationalise(line, line.lwf);
            line.position_rwf = Position_Rationalise(line, line.rwf);
            line.position_ss = Position_Rationalise(line, line.ss);
            line.position_cf = Position_Rationalise(line, line.cf);

            // Check if the player has multiple positions, then check if it equals the registered position
            int position_count = Program.Count_Bool(line.position_gk,
                                    line.position_cb,
                                    line.position_lb,
                                    line.position_rb,
                                    line.position_dmf,
                                    line.position_cmf,
                                    line.position_lmf,
                                    line.position_rmf,
                                    line.position_amf,
                                    line.position_lwf,
                                    line.position_rwf,
                                    line.position_ss,
                                    line.position_cf);

            if (position_count > 1)
            {
                Console.WriteLine(line.id + "\t" + line.name + " has proficiency in more than one position");
                variables.errors++;
            }
            else if (position_count == 0)
            {
                Console.WriteLine(line.id + "\t" + line.name + " has no proficiency in any position");
                variables.errors++;
            }
            else
            {
                if (line.position == null)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has no registered position");
                    variables.errors++;
                }
                else if (line.position.Equals("GK"))
                {
                    if (!line.position_gk)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as GK but does not have an A rating in it");
                        variables.errors++;
                    }
                }
                else if (line.position.Equals("CB"))
                {
                    if (!line.position_cb)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as CB but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_defender = true;
                    }
                }
                else if (line.position.Equals("LB"))
                {
                    if (!line.position_lb)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as LB but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_defender = true;
                    }
                }
                else if (line.position.Equals("RB"))
                {
                    if (!line.position_rb)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as RB but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_defender = true;
                    }
                }
                else if (line.position.Equals("DMF"))
                {
                    if (!line.position_dmf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as DMF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_midfielder = true;
                    }
                }
                else if (line.position.Equals("CMF"))
                {
                    if (!line.position_cmf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as CMF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_midfielder = true;
                    }
                }
                else if (line.position.Equals("LMF"))
                {
                    if (!line.position_lmf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as LMF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_midfielder = true;
                    }
                }
                else if (line.position.Equals("RMF"))
                {
                    if (!line.position_rmf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as RMF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_midfielder = true;
                    }
                }
                else if (line.position.Equals("AMF"))
                {
                    if (!line.position_amf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as AMF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_midfielder = true;
                    }
                }
                else if (line.position.Equals("LWF"))
                {
                    if (!line.position_lwf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as LWF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_striker = true;
                    }
                }
                else if (line.position.Equals("RWF"))
                {
                    if (!line.position_rwf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as RWF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_striker = true;
                    }
                }
                else if (line.position.Equals("SS"))
                {
                    if (!line.position_ss)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as SS but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_striker = true;
                    }
                }
                else if (line.position.Equals("CF"))
                {
                    if (!line.position_cf)
                    {
                        Console.WriteLine(line.id + "\t" + line.name + " is registered as CF but does not have an A rating in it");
                        variables.errors++;
                    }
                    else
                    {
                        line.is_striker = true;
                    }
                }
                else
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has an invalid registered position");
                    variables.errors++;
                }
            }
        }

        public static void check_team_positions(team squad)
        {
            uint goalkeepers = 0;
            uint defenders = 0;
            uint midfielders = 0;
            uint strikers = 0;

            // Summate players in each position
            foreach (player line in squad.team_players)
            {
                if (line.is_goalkeeper)
                {
                    goalkeepers++;
                }
                else if (line.is_defender)
                {
                    defenders++;
                }
                else if (line.is_midfielder)
                {
                    midfielders++;
                }
                else if (line.is_striker)
                {
                    strikers++;
                }
            }

            // Check against allowed minimums
            if (goalkeepers < constants.positions_minimum_gk)
            {
                Console.WriteLine(squad.team_name + " has too few Goalkeepers (Has " + goalkeepers + ", should have at least " + constants.positions_minimum_gk + ")");
                variables.errors++;
            }

            if (defenders < constants.positions_minimum_def)
            {
                Console.WriteLine(squad.team_name + " has too few Defenders (Has " + defenders + ", should have at least " + constants.positions_minimum_def + ")");
                variables.errors++;
            }

            if (midfielders < constants.positions_minimum_mf)
            {
                Console.WriteLine(squad.team_name + " has too few Midfielders (Has " + midfielders + ", should have at least " + constants.positions_minimum_mf + ")");
                variables.errors++;
            }

            if (strikers < constants.positions_minimum_fw)
            {
                Console.WriteLine(squad.team_name + " has too few Strikers (Has " + strikers + ", should have at least " + constants.positions_minimum_fw + ")");
                variables.errors++;
            }
        }

    }
}
