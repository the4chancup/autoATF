using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATF_test
{
    public class Check_InjuryTolerance
    {
        public static void check_injurytolerance(player line)
        {
            if (line.Injury_Tolerance != constants.injury_tolerance)
            {
                Console.WriteLine(line.id + "\t" + line.name + " has invalid Injury Tolerance (Is " + line.Injury_Tolerance + ", should be " + constants.injury_tolerance + ")");
                variables.errors++;
            }
        }
    }
}
