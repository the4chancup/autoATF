using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    public class Check_Position
    {
        public static string Position_Lookup(int pos)
        {
            string position = null;

            switch(pos)
            {
                case 0:
                    position = "GK";
                    break;
                case 1:
                    position = "CB";
                    break;
                case 2:
                    position = "LB";
                    break;
                case 3:
                    position = "RB";
                    break;
                case 4:
                    position = "DMF";
                    break;
                case 5:
                    position = "CMF";
                    break;
                case 6:
                    position = "LMF";
                    break;
                case 7:
                    position = "RMF";
                    break;
                case 8:
                    position = "AMF";
                    break;
                case 9:
                    position = "LWF";
                    break;
                case 10:
                    position = "RWF";
                    break;
                case 11:
                    position = "SS";
                    break;
                case 12:
                    position = "CF";
                    break;
                default:
                    position = "UNKNOWN";
                    break;
            }

            return position;
        }

        public static void check_player_positions(player line)
        {
            // Player should only have one position with an A rating
            // This position should be the registered position
            int i = 0;
            int a_ratings = 0;
            int a_position = 0;

            for(i=0;i<13;i++)
            {
                if(line.PosRats[i] == 2)
                {
                    a_ratings++;
                    a_position = i;
                }
                else if(line.PosRats[i] == 1)
                {
                    // B ratings aren't allowed ever
                    Console.WriteLine(line.id + "\t" + line.name + " has a B rating in position " + Position_Lookup(i));
                    variables.errors++;
                }
                else if(line.PosRats[i] == 0)
                {
                    // C rating is allowed
                }
                else
                {
                    // Oh shit nigga what are you doing
                    Console.WriteLine(line.id + "\t" + line.name + " has an unknown rating in position " + Position_Lookup(i));
                    variables.errors++;
                }
            }

            if (a_ratings == 0)
            {
                // Player has no A ratings
                Console.WriteLine(line.id + "\t" + line.name + " has no proficiency in any position");
                variables.errors++;
            }
            else if(a_ratings == 2)
            {
                // Player has two A ratings; could be Height Abuse System 2
                line.is_multipos_system2 = true;
            }
            else if(a_ratings >= 3)
            {
                // Player has an A rating in more than 2 positions, always forbidden
                Console.WriteLine(line.id + "\t" + line.name + " has proficiency in more than two positions");
                variables.errors++;
            }
            else // a_ratings == 1
            {
                // Check if the only A rating is the registered position
                if(!line.is_multipos_system2 && line.position != a_position)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " is registered in position " + Position_Lookup(line.position) + " but has an A Rating in " + Position_Lookup(a_position));
                    variables.errors++;
                }
                else
                {
                    // Setup the player position type
                    if(line.position == 0)
                    {
                        line.is_goalkeeper = true;
                    }
                    else if((line.position >= 1) && (line.position <= 3))
                    {
                        line.is_defender = true;
                    }
                    else if((line.position >= 4) && (line.position <= 8))
                    {
                        line.is_midfielder = true;
                    }
                    else if ((line.position >= 9) && (line.position <= 12))
                    {
                        line.is_striker = true;
                    }
                    else
                    {
                        // Oh shit nigga what are you doing
                        Console.WriteLine(line.id + "\t" + line.name + " has an invalid registered position");
                        variables.errors++;
                    }
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
