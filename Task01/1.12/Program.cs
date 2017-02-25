using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string inputStr1 = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string inputStr2 = Console.ReadLine();

            StringBuilder sb = new StringBuilder(inputStr1.Length + inputStr2.Length);

            foreach (var c in inputStr1)
            {
                if (!inputStr2.Contains(c))
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append(c, 2);
                }
            }

            Console.WriteLine("Результирующая строка: {0}", sb.ToString());
            Console.ReadKey();
        }
    }
}