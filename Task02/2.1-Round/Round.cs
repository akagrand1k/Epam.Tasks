using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1_Round
{
    public class Round
    {
        private double x;
        private double y;
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                radius = value;
            }
        }

        public Round(double x,double y)
        {
            if (x<=0 && y<=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.x = x;
            this.y = y;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetLength()
        {
            return 2 * Math.PI * radius;
        }
    }
}