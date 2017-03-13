using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._4_MyString
{
    public class MyString
    {
        private char[] myStr;


        public int Length
        {
            get
            {
                return myStr.Length;
            }
        }


        public char this[int index]
        {
            get
            {
                return myStr[index];
            }
            set
            {
                myStr[index] = value;
            }
        }

        
        public static MyString operator +(MyString s1, MyString s2)
        {
        	int L = s1.myStr.Length + s2.myStr.Length;
        	
        	MyString sumstr = new MyString(L);
        	
        	for (int i = 0; i<s1.myStr.Length; i++)
        	{
        		sumstr[i] = s1[i];
        	}
        	for (int i = 0; i<s2.myStr.Length; i++)
        	{
        		sumstr[s1.myStr.Length + i] = s2[i];
        	}
        	return sumstr;
        }

        public static MyString Concat(MyString str1,MyString str2)
        {
            MyString resultStr = new MyString();

            if (str1 == null && str2 == null)
            {
                throw new ArgumentException("Input values nullable");
            }

            if (str1 == null)
            {
                throw new ArgumentNullException("str1");
            }

            if (str2 == null)
            {
                throw new ArgumentNullException("str2");
            }

            resultStr = str1 + str2;

            return resultStr;
        }


        public static MyString Concat(params MyString[] values)
        {
            if (values == null)
            {
                throw new  NullReferenceException("values");
            }
            MyString resultStr = new MyString();

            for (int i = 0; i < values.Length; i++)
            {
                resultStr += values[i];
            }

            return resultStr;
        }

        public MyString()
        {
            myStr = new char[200];
        }

        public MyString(int sizeStr)
        {
            myStr = new char[sizeStr];
        }

        public override bool Equals(Object s1)
        {
            if (s1 == null)
            {
                throw new NullReferenceException();
            }

            if (Object.ReferenceEquals(this,s1))
            {
                return true;
            }

            return (this == s1);
        }

        public static MyString MyToString(char[] arr)
        {
            MyString result = new MyString();
            for (int i = 0; i < arr.Length; i++)
            {
                result.myStr[i] = arr[i];
            }

            return result;
        }
    }
}