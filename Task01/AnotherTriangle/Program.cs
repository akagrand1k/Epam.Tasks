using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countChar = 1;
            int countSpace = n - 1;

            for (int i = 0; i < n; i++)
            {
                PrintSpace(countSpace);
                PrintSymbol(countChar);
                PrintSpace(countSpace);
                Console.WriteLine("");
                countSpace--;
                countChar += 2;
            }
            Console.ReadKey();
        }

        static void PrintSymbol(int countChar)
        {
            for (int j = 0; j < countChar; j++)
            {
                Console.Write("*");
            }
        }

        static void PrintSpace(int countSpace)
        {
            for (int k = 0; k <= countSpace; k++)
            {
                Console.Write(" ");
            }
        }
    }
}
