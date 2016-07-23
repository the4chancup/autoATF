using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF_15
{
    class Check_Weakfoot
    {
        public static void check_manlet_weakfoot(player line)
        {
            // Is the player a manlet?
            if (line.height <= constants.weakfoot_manlet_height)
            {
                // SEC16 - Players can now have lower Weak Foot stats, but still cannot exceed the limits for their height class

                // Check manlet weak foot stats
                if (line.Weak_Foot_Accuracy > constants.weakfoot_accuracy_manlet)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has invalid Weak Foot Accuracy (Is " + line.Weak_Foot_Accuracy + ", should be " + constants.weakfoot_accuracy_manlet + " or less)");
                    variables.errors++;
                }
                if (line.Weak_Foot_Usage > constants.weakfoot_usage_manlet)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has invalid Weak Foot Usage (Is " + line.Weak_Foot_Usage + ", should be " + constants.weakfoot_usage_manlet + " or less)");
                    variables.errors++;
                }
            }
            else
            {
                // Check regular weak foot stats
                if (line.Weak_Foot_Accuracy > constants.weakfoot_accuracy)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has invalid Weak Foot Accuracy (Is " + line.Weak_Foot_Accuracy + ", should be " + constants.weakfoot_accuracy + " or less)");
                    variables.errors++;
                }
                if (line.Weak_Foot_Usage > constants.weakfoot_usage)
                {
                    Console.WriteLine(line.id + "\t" + line.name + " has invalid Weak Foot Usage (Is " + line.Weak_Foot_Usage + ", should be " + constants.weakfoot_usage + " or less)");
                    variables.errors++;
                }
            }
        }
    }
}
