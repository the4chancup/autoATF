using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AATF
{
    public class Check_InjuryTolerance
    {
        public static void check_injurytolerance(player line)
        {
            if (line.Injury_Resistance != constants.injury_tolerance)
            {
                Console.WriteLine(line.id + "\t" + line.name + " has invalid Injury Resistance (Is " + line.Injury_Resistance + ", should be " + constants.injury_tolerance + ")");
                variables.errors++;
            }
        }
    }
}
