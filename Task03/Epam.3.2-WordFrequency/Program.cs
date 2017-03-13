using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._3._2_WordFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This property tells the ASP.NET framework request request whether the handler can be used to handle"
                + " further requests. If the TELLS property returns false, then the ASP.NET framework will"
                + "create new instances for TELLS tells tells each request. ";

            var words = text.Split(new char[] { '.', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList().ConvertAll(x => x.ToLower());

            Dictionary<string, int> wordsFrequency = new Dictionary<string, int>();
            CheckFrequency(words, wordsFrequency);
            PrintDictionary(wordsFrequency);
            Console.ReadKey();
        }

        static void CheckFrequency(List<string> words, Dictionary<string, int> wordsFrequency)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (!wordsFrequency.ContainsKey(words[i]))
                {
                    wordsFrequency.Add(words[i], 1);
                }
                else
                {
                    wordsFrequency[words[i]] += 1;
                }
            }
        }

        static void PrintDictionary(Dictionary<string, int> arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }
    }
}