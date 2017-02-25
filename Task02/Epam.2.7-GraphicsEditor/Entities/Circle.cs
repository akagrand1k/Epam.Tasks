using Epam._2._7_GraphicsEditor.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._7_GraphicsEditor.Entities
{
    public class Circle : Figure, IFigureProperty
    {
        private double radius;

        public Circle()
        {

        }

        public Circle(double radius)
        {
            if (radius <=0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("The Circle is drawn,with radius =  {0}.\n Circle Perimeter = {1}", radius,GetLength);
        }

        public double GetLength
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }
    }
}
