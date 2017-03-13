using Epam._4._1_CustomSort;
using Epam._4._4_NumberArraySum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam._4._3_SortingUnit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 6, 8, 90, 150, 30, 123, 1230, 165, 0, 351, 651, 615, 6158 };
            NewThread();
        }

        private static void NewThread()
        {
            new Thread(() =>Sort(SortEnded)).Start();
        }

        private static void SortEnded()
        {
            Console.WriteLine("Sorted end successfully");
        }

        private static void Sort(Action endSort)
        {
            int[] arr = { 5, 6, 8, 90, 150, 30, 123, 1230, 165, 0, 351, 651, 615, 6158 };
            CustomSort.Sort(arr, SortCondition);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            endSort();
        }

        private static bool SortCondition(int a,int b)
        {
            return a > b;
        }
    }
}
