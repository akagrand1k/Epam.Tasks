using Epam._2._8_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._8_Game.Logic
{
    public class ObjectBehavior
    {
        Player player = new Player("Example name");
        private int bonusCount = 7;

        public void MonsterMeet(int row,int column)
        {
            if (GameMaps.GameBoard[row,column] %100 == 0 & GameMaps.GameBoard[row, column] > 100)
            {
                player.LiveNumbers-=1;
            }
        }

        public void GetBonus(int row,int column)
        {
            if (GameMaps.GameBoard[row, column] % 11 == 0 & GameMaps.GameBoard[row, column] % 4 == 0)
            {
                player.Increase++;
            }
            else
            {
                player.AdditionalLife++;
            }
            bonusCount--;
        }

        public void GameOver() // Example game over method,when bonus all bonus pickup
        {
            if (bonusCount == 0)
            {
                return;
            }
        }
    }
}
