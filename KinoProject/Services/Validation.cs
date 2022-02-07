using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject.Services
{
    class Validation
    {
        //Methods
        public static bool IsValidNum(string input)
        {
            if (input.All(char.IsDigit) && input != "")
            {
                int num = Convert.ToInt32(input);
                if (num < 1 || num > 80)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return true;
        }
        public static bool IsValid(string input)
        {
            if (input.All(char.IsDigit) && input != "")
            {
                int num = Convert.ToInt32(input);
                if (num <= 0)
                    return true;
                else
                    return false;
            }
            else
                return true;           
        }
    }
}

