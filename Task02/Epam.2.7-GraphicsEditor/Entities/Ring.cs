using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._7_GraphicsEditor.Entities
{
    class Ring : Round
    {
        private double innerR;
        private double outerR;

        public Ring(double innerR, double outerR)
        {
            if (innerR <=0 || outerR <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.innerR = innerR;
            this.outerR = outerR;
        }

        public double AreaRing
        {
            get { return Math.PI * (Math.Pow(outerR, 2) - Math.Pow(innerR, 2)); }
        }

        public object InnerLength
        {
            get
            {
                return 2 * Math.PI * innerR;
            }
        }

        public object OuterLength
        {
            get
            {
                return 2 * Math.PI * outerR;
            }
        }

        public override sealed double GetArea
        {
            get
            {
                { return Math.PI * (Math.Pow(outerR, 2) - Math.Pow(innerR, 2)); }
            }
        }

        public override void Draw()
        {
            Console.WriteLine("The Ring is draw. With parameters : \n "
                + "Inner radius =  {0}.\n"
                + "Outer radius =  {1}.\n"
                + "Ring outer perimeter = {2}\n"
                + "Ring inner perimeter = {3}\n"
                + "Ring Area = {4}\n"
                , innerR, outerR, OuterLength , InnerLength, GetArea );
        }
    }
}
