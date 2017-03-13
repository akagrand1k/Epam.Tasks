using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Epam._4._6_ISeekYou
{
    class Program
    {
        delegate bool Condition(int x);
        static Random rnd = new Random();
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            Func<int, bool> con = delegate (int x) { return x > 0; };
            int[] arr = Enumerable.Range(0, 10000)
                .Select(r => rnd.Next(-5000,5000)).ToArray();

                Console.WriteLine(sw.CheckTime(() => FindPositiveElement(arr), 1000));
                Console.WriteLine(sw.CheckTime(() => FindPositiveElement(arr, PositiveCondition), 1000));
                Console.WriteLine(sw.CheckTime(() => LambdaExpression(arr, con), 1000));
                Console.WriteLine(sw.CheckTime(() => LambdaExpression(arr, (x) => x > 0), 1000));
                Console.WriteLine(sw.CheckTime(() => arr.Where(x => x > 0), 1000));
                Thread.Sleep(5000);

            Console.ReadKey();
        }

        private static int[] FindPositiveElement(int[] array) // 1
        {
            List<int> var = new List<int>();

            if (array == null)
                throw new ArgumentNullException();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]>0)
                {
                    var.Add(array[i]);
                }
            }
            
            return var.ToArray();
        }

        private static int[] FindPositiveElement(int[] array,Condition cond) //2
        {
            List<int> var = new List<int>();

            if (array == null)
                throw new ArgumentNullException();

            if (cond == null)
                throw new ArgumentNullException(nameof(cond));

            for (int i = 0; i < array.Length; i++)
            {
                if (cond(array[i]))
                {
                    var.Add(array[i]);
                }
            }

            return var.ToArray();
        }

        private static int[] LambdaExpression(int[] array,Func<int,bool> func) //3
        {
            List<int> var = new List<int>();

            if (array == null)
                throw new ArgumentNullException();

            for (int i = 0; i < array.Length; i++)
            {
                if (func(array[i]))
                {
                    var.Add(array[i]);
                }
            }

            return var.ToArray();
        }

        private static bool PositiveCondition(int x) => x > 0;

       
    }
}