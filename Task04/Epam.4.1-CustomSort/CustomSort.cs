using System;

namespace Epam._4._1_CustomSort
{
    public static class CustomSort
    {
        /// <summary>
        /// Sorting generic arrays.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_array">Generic Array</param>
        /// <param name="TypeSort">Sort Conditions</param>
        public static void Sort<T>(T[] _array, Func<T, T, bool> TypeSort)
        {
            if (TypeSort!= null)
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    for (int j = 0; j < _array.Length - 1; j++)
                    {
                        if (TypeSort(_array[j], _array[j + 1]))
                            Swap(ref _array[j], ref _array[j + 1]);
                    }
                }
            }
        }
        
        /// <summary>
        /// Swap generic element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}