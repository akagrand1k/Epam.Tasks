using Epam._2._8_Game.Enums;
using Epam._2._8_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._8_Game.Logic
{
    /// <summary>
    /// Random generate objects for filling maps
    /// </summary>
    public static class GenerateObjects
    {
        private static Random rnd = new Random();

        public static int[] GenerateMobs()
        {
            var values = Enum.GetValues(typeof(Monster));
            int[] arr = new int[7]; //Count mobs
            RandomFillArray(values, arr);
            return arr;
        }

        public static int[] GenerateBonus()
        {
            var values = Enum.GetValues(typeof(Bonus));
            int[] arr = new int[10]; //Count bonus
            RandomFillArray(values, arr);
            return arr;
        }

        public static int[] GenerateObstruction()
        {
            var values = Enum.GetValues(typeof(Obstruction));
            int[] arr = new int[5]; //Count obstruction
            RandomFillArray(values, arr);
            return arr;
        }

        private static void RandomFillArray(Array values, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (int)values.GetValue(rnd.Next(values.Length));
            }
        }
    }
}
