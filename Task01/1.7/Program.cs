using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int n = int.Parse(Console.ReadLine());
            int min;
            int max = 0;
            int[] arr = new int[n];

            RandomFill(rnd, arr);
            min = arr[0];
            FindMaxMin(ref min, ref max, arr);
            Console.WriteLine("Min = {0}, Max = {1}", min, max);

            SortArray(arr);
            foreach (var item in arr)
            {
                Console.Write("{0};", item);
            }

            Console.ReadKey();
        }

        private static void RandomFill(Random rnd, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 1000);
            }
        }

        private static void FindMaxMin(ref int min, ref int max, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] > max)
                {
                    max = arr[i];
                }

                if (arr[i] <= min)
                {
                    min = arr[i];
                }
            }
        }

        static void SortArray(int[] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length-1; i++)
                {
                    if (arr[i + 1] < arr[i])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                    }
                }
            }
        }

        static void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
    }
}
