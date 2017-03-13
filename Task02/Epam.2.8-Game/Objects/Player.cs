using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._8_Game.Objects
{
    public class Player
    {
        private int sizeIncrease; // Size player
        private int additionalLife;
        private int liveNumbers;
        private int score;

        public Player(string name)
        {
            Name = name;
            LiveNumbers = 2;
            Increase = 0;
            additionalLife = 0;
            score = 0;
        }

        public string Name { get; set; }
        public int LiveNumbers
        {
            get
            {
                return liveNumbers;
            }
            set
            {
                if (LiveNumbers==0)
                {
                    throw new Exception("Oops Player death,Live end");
                }
                liveNumbers = value;
            }
        }

        public int Increase
        {
            get
            {
                return sizeIncrease;
            }
            set
            {
                sizeIncrease = value;
                if (Increase >=5)
                {
                    Increase = 5;
                }
            }
        }

        public int AdditionalLife
        {
            get
            {
                return additionalLife;
            }
            set
            {
                additionalLife = value;
                if (additionalLife >= 2)
                {
                    additionalLife = 2;
                }
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
    }
}