using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._3._1_Lost
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            LinkedList<int> people = FeelLinkList(n);
            var firstElement = people.First;

            while (people.Count > 1)
            {
                people.Remove(firstElement.Next ?? people.First);
            }

            Console.WriteLine(people.Count);
            Console.ReadKey();
        }

        static LinkedList<int> FeelLinkList(int n)
        {
            var temp = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                temp.AddLast(i);
            }
            return temp;
        }
    }
}
