using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATF_test
{
    class Height_Abuse
    {
        public static void check_height_abuse(team squad)
        {
            uint bracket_1 = 0; // 200-205
            uint bracket_2 = 0; // 195-199
            uint bracket_3 = 0; // 190-194
            uint bracket_4 = 0; // 185-189
            uint bracket_5 = 0; // 180-184
            uint bracket_6 = 0; // 175-179
            uint bracket_7 = 0; // 170-174
            uint bracket_8 = 0; // 165-169

            uint height_total = 0; // 4200

            // Check heights of all players in team
            foreach (player line in squad.team_players)
            {
                // Add height to running total for team
                height_total += line.height;

                // Check height against bracket boundaries, increment number of players in the bracket
                if (line.height > constants.height_maximum_pes)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + line.id + "\t" + line.name + " has a height of " + line.height + ", which is above the PES limit of " + constants.height_maximum_pes + "\nThis will probably crash the game. Good job.");
                    variables.errors++;
                }
                else if (line.height > constants.height_maximum_4cc)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + line.id + "\t" + line.name + " has a height above the 4cc limit of " + constants.height_maximum_4cc);
                    variables.errors++;
                }
                else if (line.height >= constants.height_bracket_1)
                {
                    bracket_1++;
                }
                else if (line.height >= constants.height_bracket_2)
                {
                    bracket_2++;
                }
                else if (line.height >= constants.height_bracket_3)
                {
                    bracket_3++;
                }
                else if (line.height >= constants.height_bracket_4)
                {
                    bracket_4++;
                }
                else if (line.height >= constants.height_bracket_5)
                {
                    bracket_5++;
                }
                else if (line.height >= constants.height_bracket_6)
                {
                    bracket_6++;
                }
                else if (line.height >= constants.height_bracket_7)
                {
                    bracket_7++;
                }
                else if (line.height >= constants.height_bracket_8)
                {
                    bracket_8++;
                }
                else if (line.height >= constants.height_minimum_pes)
                {
                    Console.WriteLine("MANLET ABUSE:\n" + line.id + "\t" + line.name + " has a height below the 4cc limit of " + constants.height_bracket_8);
                    variables.errors++;
                }
                else
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has an invalid height and may crash the game\nYou must have seriously fucked up your export to trigger this");
                    variables.errors++;
                }
            }

             // Is height_abuse_brackets enabled?
            if (switches.enable_height_abuse_bracket_check)
            {
                // Check for too many players in a height bracket
                if (bracket_1 > constants.height_bracket_1_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_1 + "-" + constants.height_maximum_4cc + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_1 + " out of " + constants.height_bracket_1_limit + ")");
                    variables.errors++;
                }

                if (bracket_2 > constants.height_bracket_2_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_2 + "-" + (constants.height_bracket_1 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_2 + " out of " + constants.height_bracket_2_limit + ")");
                    variables.errors++;
                }

                if (bracket_3 > constants.height_bracket_3_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_3 + "-" + (constants.height_bracket_2 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_3 + " out of " + constants.height_bracket_3_limit + ")");
                    variables.errors++;
                }

                if (bracket_4 > constants.height_bracket_4_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_4 + "-" + (constants.height_bracket_3 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_4 + " out of " + constants.height_bracket_4_limit + ")");
                    variables.errors++;
                }

                if (bracket_5 > constants.height_bracket_5_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_5 + "-" + (constants.height_bracket_4 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_5 + " out of " + constants.height_bracket_5_limit + ")");
                    variables.errors++;
                }

                if (bracket_6 > constants.height_bracket_6_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_6 + "-" + (constants.height_bracket_5 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_6 + " out of " + constants.height_bracket_6_limit + ")");
                    variables.errors++;
                }

                if (bracket_7 > constants.height_bracket_7_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_7 + "-" + (constants.height_bracket_6 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_7 + " out of " + constants.height_bracket_7_limit + ")");
                    variables.errors++;
                }

                if (bracket_8 > constants.height_bracket_8_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too many players in the " + constants.height_bracket_8 + "-" + (constants.height_bracket_7 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_8 + " out of " + constants.height_bracket_8_limit + ")");
                    variables.errors++;
                }


                // Check for too few players in a height bracket
                if (bracket_1 < constants.height_bracket_1_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_1 + "-" + constants.height_maximum_4cc + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_1 + " out of " + constants.height_bracket_1_limit + ")");
                    variables.errors++;
                }

                if (bracket_2 < constants.height_bracket_2_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_2 + "-" + (constants.height_bracket_1 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_2 + " out of " + constants.height_bracket_2_limit + ")");
                    variables.errors++;
                }

                if (bracket_3 < constants.height_bracket_3_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_3 + "-" + (constants.height_bracket_2 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_3 + " out of " + constants.height_bracket_3_limit + ")");
                    variables.errors++;
                }

                if (bracket_4 < constants.height_bracket_4_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_4 + "-" + (constants.height_bracket_3 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_4 + " out of " + constants.height_bracket_4_limit + ")");
                    variables.errors++;
                }

                if (bracket_5 < constants.height_bracket_5_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_5 + "-" + (constants.height_bracket_4 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_5 + " out of " + constants.height_bracket_5_limit + ")");
                    variables.errors++;
                }

                if (bracket_6 < constants.height_bracket_6_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_6 + "-" + (constants.height_bracket_5 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_6 + " out of " + constants.height_bracket_6_limit + ")");
                    variables.errors++;
                }

                if (bracket_7 < constants.height_bracket_7_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_7 + "-" + (constants.height_bracket_6 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_7 + " out of " + constants.height_bracket_7_limit + ")");
                    variables.errors++;
                }

                if (bracket_8 < constants.height_bracket_8_limit)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has too few players in the " + constants.height_bracket_8 + "-" + (constants.height_bracket_7 - 1) + " bracket");
                    Console.WriteLine("\t\t (Has " + bracket_8 + " out of " + constants.height_bracket_8_limit + ")");
                    variables.errors++;
                }
            }

            if (switches.enable_height_abuse_sum_check == true)
            {
                // Check total team height
                if (height_total > constants.height_limit_total)
                {
                    Console.WriteLine("HEIGHT ABUSE:\n" + squad.team_name + " has broken the total height limit of " + constants.height_limit_total);
                    Console.WriteLine("\t\t (Has " + height_total + " out of " + constants.height_limit_total + ")");
                    variables.errors++;
                }
            }
        }
    }
}
