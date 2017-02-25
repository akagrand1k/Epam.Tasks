using Epam._2._7_GraphicsEditor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._7_GraphicsEditor.Entities
{
    public class Round : Circle, IAreaContract
    {
        private double radius;

        public Round()
        {

        }

        public Round(double radius)
        {
            if (radius<=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.radius = radius;
        }


        public override void Draw()
        {
            Console.WriteLine("The Round is drawn,with radius =  {0}.\n Round Perimeter = {1}\n  Round Area = {2}\n"
                , radius, GetLength,GetArea);
        }

        public virtual double GetArea
        {
            get
            {
                return Math.PI * Math.Pow(radius, 2);
            }
        }
    }
}
