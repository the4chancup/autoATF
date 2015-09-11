using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF_15
{
    public class Check_Form
    {
        public static void check_form(player line)
        {
            // Check what type the player is, and check if they have the right form for that type

            if (line.is_gold == true)
            {
                if (line.Form != constants.form_gold)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has wrong Form (Is " + line.Form + ", should be " + constants.form_gold + ")");
                    variables.errors++;
                }
            }

            if (line.is_silver == true)
            {
                if (line.Form != constants.form_silver)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has wrong Form (Is " + line.Form + ", should be " + constants.form_silver + ")");
                    variables.errors++;
                }
            }

            if (line.is_regular == true)
            {
                if (line.Form != constants.form_regular)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has wrong Form (Is " + line.Form + ", should be " + constants.form_regular + ")");
                    variables.errors++;
                }
            }

            if (line.is_goalkeeper == true)
            {
                if (line.Form != constants.form_goalkeeper)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has wrong Form (Is " + line.Form + ", should be " + constants.form_goalkeeper + ")");
                    variables.errors++;
                }
            }

            // If the player doesn't have a type marker set
            if (!line.is_gold && !line.is_silver && !line.is_regular && !line.is_goalkeeper)
            {
                Console.WriteLine(line.id + "\t" + line.name + " has invalid stats, so Form cannot be checked");
                variables.errors++;
            }
        }
    }
}
