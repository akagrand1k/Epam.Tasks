using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Round
{
    class Program
    {
        static void Main(string[] args)
        {
            Round round = new Round(-2,3);
            round.Radius = 10;

            Console.WriteLine("Area circle = {0}. Length circle = {1}",round.GetArea(),round.GetLength());
        }
    }
}
