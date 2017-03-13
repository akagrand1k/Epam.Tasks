using Epam._4._1_CustomSort;
using Epam._4._5_ToIntOrNotInt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._4._2_CustomSortDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "Hello", "World", "It's", "2017", "Year", "ddasdasdsa5555", "2", "555555", "6666dd" };
            CustomSort.Sort(words, SortConditional);

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static bool SortConditional(string a,string b)
        {
            if (a.Length == b.Length)
                return (string.Compare(a, b,true) == -1);

            return a.Length > b.Length;
        }
    }
}
