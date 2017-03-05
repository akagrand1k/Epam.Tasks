using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._3._3_DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];
            arr[0] = 5;
            arr[1] = 6;
            arr[2] = 3;
            DynamicArray<int> str = new DynamicArray<int>(arr);
            str.Insert(55, 1);
            Console.ReadKey();
        }
    }
}
