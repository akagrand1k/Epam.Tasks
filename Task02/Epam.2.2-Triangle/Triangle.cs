using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._2_Triangle
{
    public class Triangle
    {
        private double a, b, c;

        public Triangle(int a,int b,int c)
        {
            if (a<=0 && b<=0 && c<=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.a = a;
            this.b = b;
            this.c = c;
        }
        private double SemiPerimeter
        {
            get
            {
                return (a + b + c) / 2;
            }
        }

        public double GetLength
        {
            get
            {
                return a + b + c;
            }
        }
        
        public double GetArea
        {
            get
            {
                return Math.Sqrt(SemiPerimeter * (SemiPerimeter - a) * (SemiPerimeter - b) * (SemiPerimeter - c));
            }
        }

        public bool IsValid()
        {
            if (a < (b + c) & b < (a + c) & c < (a + b))
            {
                Console.WriteLine("Triangle valid");
                return true;
            }
            else
            {
                Console.WriteLine("Triangle not valid");
                return false;
            }
        }
    }
}