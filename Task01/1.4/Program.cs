using System;

namespace _1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countChar;
            int countSpace;
            int row = 0;
            for (int i = 0; i < n; i++)
            {
                row = PaintTree(n, out countChar, out countSpace, row);
            }
            Console.ReadKey();
        }

        static int PaintTree(int n, out int countChar, out int countSpace, int row)
        {
            {
                countChar = 1;
                countSpace = n - 1;
                for (int j = 0; j <= row; j++)
                {
                    for (int f = 0; f < countSpace; f++)
                    {
                        Console.Write(" ");
                    }
                    for (int g = 0; g < countChar; g++)
                    {
                        Console.Write("*");
                    }
                    for (int f = 0; f < countSpace; f++)
                    {
                        Console.Write(" ");
                    }
                    countChar += 2;
                    countSpace--;
                    Console.WriteLine();
                }
                Console.WriteLine();
                row++;
            }

            return row;
        }
    }
}