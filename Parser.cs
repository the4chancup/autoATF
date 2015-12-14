using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace AATF_15
{
    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public IniFile(string INIPath)
        {
            path = INIPath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();
        }
    }

    public class Parser
    {
        public static bool setup_switches()
        {
            Console.Write("Parsing ini file...");

            // Load ini file
            IniFile ini = new IniFile(".//autoATF.ini");

            // Parse the edit.bin
            switches.input_file = ini.IniReadValue("Input", "input.bin");

            // Parse the comparison file,
            switches.compare_file = ini.IniReadValue("Input", "compare.bin");

            // Verification that the ini file is there
            if (switches.input_file == "")
            {
                Console.Write("\tFailed!");
                Console.WriteLine("\nERROR: ini file not found");
                Console.WriteLine("\nMake sure it is present in the same directory as the exe");
                Console.WriteLine();
                return false;
            }

            if(!File.Exists(switches.input_file))
            {
                Console.Write("\tFailed!");
                Console.WriteLine("\nERROR: specified edit.bin not found");
                Console.WriteLine("\nMake sure the edit.bin is present in the same directory as the exe");
                Console.WriteLine("\nMake sure the edit.bin filename specified in the ini is correct");
                Console.WriteLine();
                return false;
            }

            // If there is a compare file, verify that it is actually there
            if(switches.compare_file != "")
            {
                if(!File.Exists(switches.input_file))
                {
                    Console.Write("\tFailed!");
                    Console.WriteLine("\nERROR: specified compare.bin not found");
                    Console.WriteLine("\nMake sure the compare.bin is present in the same directory as the exe");
                    Console.WriteLine("\nMake sure the compare.bin filename specified in the ini is correct");
                    Console.WriteLine("\nIf you do not want to compare, leave the compare.bin field blank");
                    Console.WriteLine();
                    return false;
                }
            }

            // Ensure the pes16decrypter DLL is present, or we won't be able to decrypt any files
            if(!File.Exists("cygpes16decrypter.dll"))
            {
                Console.Write("\tFailed!");
                Console.WriteLine("\nERROR: cygpes16decrypter.dll not found");
                Console.WriteLine("\nMake sure the cygpes16decrypter.dll is present in the same directory as the exe");
                Console.WriteLine();
                return false;
            }

            Console.Write("\tComplete!");
            Console.WriteLine();

            return true;
        }
    }
}
