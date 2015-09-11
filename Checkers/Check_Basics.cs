using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF_15
{
    public class Check_Basics
    {
        public static void check_basics(player line)
        {
            // Age Abuse
            if((line.age > constants.age_maximum) || (line.age < constants.age_minimum))
            {
                Console.WriteLine(line.id + "\t" + line.name + " has an invalid Age!");
                Console.WriteLine("\t\t(Is " + line.age + ", should be between " + constants.age_minimum + " and " + constants.age_maximum + ")");
                variables.errors++;
            }

            // Weight Abuse
            // Calculate the weight boundaries for their height
            int weight_max, weight_min;

            weight_max = line.height - 81;
            weight_min = line.height - 129;

            if(weight_min < 30)
            {
                weight_min = 30;
            }

            if((line.weight > weight_max) || (line.weight < weight_min))
            {
                Console.WriteLine(line.id + "\t" + line.name + " has an invalid Weight!");
                Console.WriteLine("\t\t(Is " + line.weight + ", should be between " + weight_min + " and " + weight_max + ")");
                variables.errors++;
            }
        }




    }
}
