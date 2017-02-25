using Epam._2._5_Ring;
using System;

namespace Epam._2._6_Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring();
            ring.OuterRadius = 7;
            ring.InnerRadius = 4;

            Console.WriteLine("Area ring = {0}\n", ring.AreaRing);
            Console.WriteLine("Outer length circle = {0}", ring.OuterLength);
            Console.WriteLine("Inner length circle = {0}", ring.InnerLength);
            Console.ReadKey();
        }
    }
}