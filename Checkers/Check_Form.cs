using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    public class Check_Form
    {
        public static void check_form(player line)
        {
            // Check what type the player is, and check if they have the right form for that type

            // If there was no stat type assigned
            if (line.statType == 0)
            {
                Console.WriteLine(line.id + "\t" + line.name + " has invalid stats, so Form cannot be checked");
                variables.errors++;
            }
            // If things are good, check
            else
            {
                if (line.Form != constants.form[line.ptype])
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has wrong Form (Is " + line.Form + ", should be " + constants.form[line.ptype] + ")");
                    variables.errors++;
                }
            }
        }
    }
}
