using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._4._5_ToIntOrNotInt
{
    public static class StringExtension
    {
        public static bool CheckPositiveDigit(this string str)
        {
            return ToInt(str)>0;
        }

        private static int ToInt(string str)
        {
            int result = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    result = result * 10 + ChatToInt(str[i]);
                }
            }
            return result;
        }
        private static int ChatToInt(char ch)
        {
            return ch - '0';
        }
    }
}
