using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._4_MyString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Шла Саша по шоссе и соссала сушку!!!";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                sb.Append(s);
            }
        }
    }
}