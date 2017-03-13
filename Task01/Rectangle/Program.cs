using System;

namespace Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.a = 0;
            rect.b = 0;
            
            bool IsValidA = true;
            bool IsValidB = true;

            while (IsValidA)
            {
                Console.WriteLine("Please, enter - A.");
                IsValidA = ParseNumber(Console.ReadLine(), out rect.a);
                IsValidA = Repeat(rect.a);
            }

            while (IsValidB)
            {
                Console.WriteLine("Please, enter - B.");
                ParseNumber(Console.ReadLine(), out rect.b);
                IsValidB = Repeat(rect.b);
            }

            Console.WriteLine("Rectangle Area = {0}.",rect.Area);

            Console.ReadKey();
        }

        static bool ParseNumber(string str,out int c)
        {
            if (!int.TryParse(str, out c))
            {
                return false;
            }
            return true;
        }

        static bool Repeat(int value)
        {
            if (value <= 0)
            {
                Console.WriteLine("Invalid value,Please repeat.\n");
                return true;
            }
            else
            {
                Console.WriteLine("Side ={0}.", value);
                return false;
            }
        }
    }
}