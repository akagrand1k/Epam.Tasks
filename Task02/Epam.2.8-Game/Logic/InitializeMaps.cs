using Epam._2._8_Game.Objects;
using System;

namespace Epam._2._8_Game.Logic
{
    public class InitializeMaps
    {
        private static Random rnd = new Random();
        private int width;
        private int height;

        public InitializeMaps(int width, int height)
        {
            if (width <= 0 && height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.width = width;
            this.height = height;
            CreateMap();
            MonsterFill();
            BonusFill();
            ObstructionFill();
        }

        private void CreateMap()
        {
            GameField tField = new GameField(width, height);
            GameMaps.GameBoard = tField.CreateGamePlace;
        }

        /// <summary>
        /// Random monster filling gameboard.
        /// Minimal position fill - (1,3).
        /// </summary>
        private void MonsterFill()
        {
            int row = 0;
            int column = 0;
            int[] tArray = GenerateObjects.GenerateMobs();
            for (int i = 0; i < tArray.Length; i++)
            {
                CheckValidateCell(ref row, ref column, tArray, i);
            }
        }

        /// <summary>
        /// Random bonus filling gameboard.
        /// Minimal position fill - (1,3).
        /// </summary>
        private void BonusFill()
        {
            int row = 0;
            int column = 0;
            int[] tArray = GenerateObjects.GenerateBonus();
            for (int i = 0; i < tArray.Length; i++)
            {
                CheckValidateCell(ref row, ref column, tArray, i);
            }
        }

        /// <summary>
        /// Random obstruction filling gameboard.
        /// Minimal position fill - (1,3).
        /// </summary>
        private void ObstructionFill()
        {
            int row = 0;
            int column = 0;
            int[] tArray = GenerateObjects.GenerateBonus();
            for (int i = 0; i < tArray.Length; i++)
            {
                CheckValidateCell(ref row, ref column, tArray, i);
            }
        }

        /// <summary>
        /// Check Cell for empty in array, for initialize.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="tArray"></param>
        /// <param name="i"></param>
        private void CheckValidateCell(ref int row, ref int column, int[] tArray, int i)
        {
            bool flag = true;
            while (flag)
            {
                row = rnd.Next(GameMaps.GameBoard.GetLength(rnd.Next(1, height)));
                column = rnd.Next(GameMaps.GameBoard.GetLength(rnd.Next(1, width)));
                if (GameMaps.GameBoard[row, column] == 0)
                {
                    if (GameMaps.GameBoard[row + 1, column] == 0 & GameMaps.GameBoard[row, column + 1] == 0
                    & GameMaps.GameBoard[row - 1, column] == 0 & GameMaps.GameBoard[row, column - 1] == 0)
                    {
                        GameMaps.GameBoard[row, column] = tArray[i];
                        flag = false;
                    }
                }
            }
        }
    }
}