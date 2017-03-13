using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._11
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            var sb1 = new StringBuilder();

            foreach (char s in str)
            {
                if (!char.IsPunctuation(s))
                {
                    sb1.Append(s);
                }
            }

            string[] words = sb1.ToString().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int charCount =  0;
            for (int i = 0; i < words.Length; i++)
            {
                 charCount += words[i].Length;
            }

            int averageLength = charCount/words.Length;
            Console.WriteLine("Average length words = {0}",averageLength);
            Console.ReadKey();
        }
    }
}