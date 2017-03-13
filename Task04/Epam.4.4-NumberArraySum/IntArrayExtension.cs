using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._4._4_NumberArraySum
{
    public static class IntArrayExtension
    {
        public static int SumArray(this int[] arr)
        {
            var sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
    }
}
