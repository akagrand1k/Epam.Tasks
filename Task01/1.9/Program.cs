using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._9
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] arr = new int[n];

            RandomFill(arr);
            sum = TotalPositive(sum, arr);

            foreach (var item in arr)
            {
                Console.Write("{0}\t", item);
            }

            Console.WriteLine("\nSum non-negative array elements = {0}", sum);
            Console.ReadKey();
        }

        static void RandomFill(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }
        }

        static int TotalPositive(int sum, int[] arr)
        {
            for (int k = 0; k < arr.Length; k++)
            {
                if (arr[k] > 0)
                {
                    sum += arr[k];
                }
            }
            return sum;
        }
    }
}
