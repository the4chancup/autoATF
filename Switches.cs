using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace AATF
{
    public class switches
    {
        static string _input_file;

        public static string input_file
        {
            get
            {
                return _input_file;
            }
            set
            {
                _input_file = value;
            }
        }

        static string _compare_file;

        public static string compare_file
        {
            get
            {
                return _compare_file;
            }
            set
            {
                _compare_file = value;
            }
        }
    }
}
