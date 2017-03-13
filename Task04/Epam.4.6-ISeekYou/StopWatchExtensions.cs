using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._4._6_ISeekYou
{
    public static class StopWatchExtensions
    {
        public static long CheckTime(this Stopwatch sw,Action action,int iterations)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            sw.Reset();
            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }
    }
}
