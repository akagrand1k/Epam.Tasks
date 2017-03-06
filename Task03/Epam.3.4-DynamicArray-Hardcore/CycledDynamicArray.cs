using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._3._4_DynamicArray_Hardcore
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public override IEnumerator GetEnumerator()
        {
            while (true)
            {
                foreach (var item in (DynamicArray<T>)this)
                {
                    yield return item;
                }
            }
        }
    }
}