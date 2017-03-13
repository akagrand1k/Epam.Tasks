using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._8_Game.Objects
{
    public class GameField
    {
        private int width, height;

        public GameField(int width,int height)
        {
            if (width<height)
            {
                throw new Exception("Width less than the height");
            }
            if (width<=0 || height<=0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.width = width;
            this.height = height;
        }

        public int[,] CreateGamePlace
        {
            get
            {
                int[,] temp = new int[height, width];
                return temp;
            }
        }
    }
}
