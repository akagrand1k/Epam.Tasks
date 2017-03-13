using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 3 * summMultipleArr(999/3) + 5 * summMultipleArr(999/5) - 15 * summMultipleArr(999/15);
            Console.WriteLine("Total sum = {0}",total);
            Console.ReadKey();
        }

        static int summMultipleArr(int n)
        {
            return (n * (n + 1)) / 2;
        }
    }
}