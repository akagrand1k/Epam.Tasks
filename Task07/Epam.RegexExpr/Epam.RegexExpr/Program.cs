using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Epam.RegexExpr
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //DateExistance();
            //HtmlReplacer();
            //EmailFinder();
            //NumberValidator();
            TimeCounter();
        }

        static void DateExistance()
        {
            Console.Write("Введите текст содержащий дату в формате dd-mm-yyyy:  ");
            var str = Console.ReadLine();
            Regex reg = new Regex(@"[0-3]\d-[0-1][1-9]-\d{4}");
            MatchCollection matches = reg.Matches(str);
            if (matches.Count>0)
                Console.WriteLine($"В тексте \"{str}\" присутствует дата");
            Console.ReadKey();
        }

        static void HtmlReplacer()
        {
            string html = "<div class=\"title tools\"><span>Tools</span><ul class=\"buttonbar right>\"<li class=\"button nolabel expand\" data-icon=&#xE192; data-alticon=&#xE191;></li></ul>" 
                +"<ul class=\"buttonbar left\"><li class=\"button replace active\" data-tool=replace>Replace</li>";
            string html2 = "<meta content = \"true\" name=\"octolytics-dimension-public\" /><meta content = \"27545952\" name=\"octolytics-dimension-gist_id\" /><meta content = \"53eeccd2b7fce2e1c73b\" name=\"octolytics-dimension-gist_name\" /><meta content = \"false\" name=\"octolytics-dimension-anonymous\" /><meta content = \"10222521\" name=\"octolytics-dimension-owner_id\" /><meta content = \"vanillajonathan\" name=\"octolytics-dimension-owner_login\" /><meta content = \"false\" name=\"octolytics-dimension-forked\" />< meta class=\"js-ga-set\" name=\"dimension5\" content=\"public\">"
                + "<meta class=\"js-ga-set\" name=\"dimension6\" content=\"owned\"> HELLO WORLD"
                + "<meta class=\"js-ga-set\" name=\"dimension7\" content=\"c#\">";
  
            Regex reg = new Regex("<[^>]*>");
            Console.WriteLine(reg.Replace(html, "_"));
            Console.WriteLine(reg.Replace(html2, "_"));
            Console.ReadKey();
        }

        static void EmailFinder()
        {
            Regex reg = new Regex(@"[a-zA-Z0-9][a-zA-Z0-9._-]+[a-zA-Z0-9]@[а-яА-ЯЁёa-zA-Z-.]+\.[a-zA-Zа-яА-ЯёЁ]{2,6}");
            Console.Write("Введите строку: ");
            var str = Console.ReadLine();
            var matchCollection = reg.Matches(str);
            Console.WriteLine("Найденные адреса электронной почты:");
            foreach (var item in matchCollection)
            {
                Console.WriteLine(item); ;
            }
            Console.ReadKey();
        }

        static void NumberValidator()
        {
            Regex reg = new Regex(@"(?:\+|\-)?[0-9]+(?:\.[0-9]+)?(?:e(?:\+|\-)?[0-9]+)?");
            Console.Write("Введите число:");
            var str = Console.ReadLine();
            if (reg.IsMatch(str))
                Console.WriteLine("Это вещественное число");
            else
                Console.WriteLine("Это не число");
            Console.ReadKey();
        }

        static void TimeCounter()
        {
            Regex reg = new Regex(@"(?:[01]?\d|2[0-3]):(?:[0-5]\d)");
            Console.Write("Введите строку: ");
            var str = Console.ReadLine();
            var matches = reg.Matches(str);
            Console.WriteLine($"Время в тексте присутствует {matches.Count} раз");
            Console.ReadKey();
        }
    }
}