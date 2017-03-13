using System;

namespace _1._10
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int[,] arr = new int[x, y];
            int oddSum = 0;
            int total = 0;
            RandomFill(x, y, arr);
            total = GetTotalSum(x, y, arr, total);
            oddSum = GetOddSum(x, y, arr, oddSum);

            Console.WriteLine("Sum even index elements ={0}", total - oddSum);
            Console.ReadKey();
        }

        static int GetOddSum(int x, int y, int[,] arr, int oddSum)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        oddSum += arr[i, j];
                    }
                }
            }

            return oddSum;
        }

        static int GetTotalSum(int x, int y, int[,] arr, int total)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    total += arr[i, j];
                }
            }

            return total;
        }

        static void RandomFill(int x, int y, int[,] arr)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    arr[i, j] = rnd.Next(-100, 100);
                }
            }
        }
    }
}