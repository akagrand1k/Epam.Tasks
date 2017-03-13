using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._5_Ring
{
    public class Ring
    {
        private double innerR;
        private double outerR;

        public double InnerRadius
        {
            get { return innerR; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                innerR = value;
            }
        }

        public double OuterRadius
        {
            get { return outerR; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                outerR = value;
            }
        }

        public double AreaRing
        {
            get { return Math.PI * (Math.Pow(outerR, 2) - Math.Pow(innerR, 2)); }
        }

        public double OuterLength
        {
            get
            {
                return 2 * Math.PI * OuterRadius;
            }
        }

        public double InnerLength
        {
            get
            {
                return 2 * Math.PI * InnerRadius;
            }
        }
    }
}
