using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._2_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter side triangle:\n");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Triangle triangle = new Triangle(a,b,c);
            if (triangle.IsValid())
            {
                Console.WriteLine("Perimeter Triangle = {0}\nArea Triangle = {1}", triangle.GetLength, triangle.GetArea);
            }            
            Console.ReadKey();
        }
    }
}