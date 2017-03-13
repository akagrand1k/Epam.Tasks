using Epam._2._7_GraphicsEditor.Contracts;
using System;

namespace Epam._2._7_GraphicsEditor.Entities
{
    public class Rectangle : Figure, IFigureProperty, IAreaContract
    {
        private double x, y;

        public Rectangle(int x,int y)
        {
            if (x<=0 || y<= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.x = x;
            this.y = y;
        }

        public double GetArea
        {
            get
            {
                return x* y;
            }
        }

        public double GetLength
        {
            get
            {
                return (x + y) * 2;
            }
        }

        public override void Draw()
        {
            Console.WriteLine("The Rectangle is drawn,with side:"
                + "A =  {0}\n"
                + "B = {1} \n"
                + "Rectangle perimeter = {2}\n"
                + "Rectangle area = {3} \n"
                , x,y,GetLength, GetArea);
        }
    }
}
