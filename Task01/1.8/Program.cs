using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            int[,,] arr = new int[x, y, z];
            RandomFill(x, y, z, rnd, arr);
            PrintArray(x, y, z, arr);
            ReplaceToNull(x, y, z, arr);
            Console.WriteLine("Replace 3D-Array: ");
            PrintArray(x, y, z, arr);
            Console.ReadKey();
        }

        static void ReplaceToNull(int x, int y, int z, int[,,] arr)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }
        }

        static void PrintArray(int x, int y, int z, int[,,] arr)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        Console.Write("{0}\t", arr[i, j, k]);
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
        }

        static void RandomFill(int x, int y, int z, Random rnd, int[,,] arr)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        arr[i, j, k] = rnd.Next(-100, 100);
                    }
                }
            }
        }
    }
}