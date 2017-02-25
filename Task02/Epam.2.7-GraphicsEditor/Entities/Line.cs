using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._7_GraphicsEditor.Entities
{

    class Line : Figure
    {
        private int x, y;

        public Line(int x, int y)
        {
            if (x <= 0 || y <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.x = x;
            this.y = y;
        }

        public override void Draw()
        {
            Console.WriteLine("The line is drawn,with point =  {0};{1}", x, y);
        }
    }
}
