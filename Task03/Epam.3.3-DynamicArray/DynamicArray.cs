using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._3._3_DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] myArr;
        private int length;
        private int capacity;

        public DynamicArray()
        {
            myArr = new T[8];
            this.capacity = 8;
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            this.capacity = capacity;
            myArr = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> coll)
        {
            this.capacity = coll.Count();
            length += capacity;
            myArr = new T[capacity];
            Array.Copy((Array)coll, myArr, coll.Count());
        }

        public void Add(T item)
        {
            if (length == capacity - 1)
                capacity = capacity * 2;
            Array.Resize(ref myArr, capacity);
            myArr[length] = item;
            length++;
        }

        public void AddRange(IEnumerable<T> item)
        {
            int countElement = item.Count();
            if (countElement < 0)
                throw new ArgumentOutOfRangeException();
            Array.Resize(ref myArr, capacity+countElement * 2);
            Array.Copy((Array)item, 0, myArr, length, countElement);
            length += countElement;
            capacity += countElement;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                if (myArr[i].Equals(item))
                {
                    RemoveByIndex(i);
                    return true;
                }
            }
            return false;
        }

        public bool Insert(T item,int index)
        {
            if (index > length)
                throw new ArgumentOutOfRangeException();

            if (index < length)
            {
                if (capacity == length)
                {
                    capacity += 1;
                    Array.Resize(ref myArr, capacity);
                }
                Array.Copy(myArr, index, myArr, index + 1, length - index);
                myArr[index] = item;
                length++;
                
                return true;
            }
            return false;
        }
       
        public int Capacity
        {
            get
            {
                if (capacity < 0)
                    throw new ArgumentException();
                return capacity;
            }
        }

        public int Length
        {
            get
            {
                if (length<0)
                    throw new ArgumentNullException();
                return length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 && index >= myArr.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return myArr[index];
            }
            set
            {
                if (index < 0 && index >= myArr.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                myArr[index] = value;
                length++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return myArr.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in myArr)
            {
                yield return item;
            }
        }

        private bool RemoveByIndex(int index)
        {
            if (index > length)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            if (index + 1 < length)
            {
                capacity--;
                Array.Copy(myArr, index, myArr, index-1, length);
                Array.Resize(ref myArr,capacity);
            }
            length--;
            return true;
        }
    }
}