using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6
{
    class Program
    {
        static Font font = new Font();
        static void Main(string[] args)
        {
            string style;
            string exit = string.Empty;

            PrintParameters();
            do
            {
                style = Console.ReadLine();
                switch (style)
                {
                    case "1":
                        CheckBold();
                        PrintParameters();
                        break;

                    case "2":
                        CheckItalic();
                        PrintParameters();
                        break;
                    case "3":
                        CheckUnderline();
                        PrintParameters();
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.Если хотите выйти,введите - Выход");
                        exit = Console.ReadLine();
                        break;
                }
            }
            while (exit != "Выход");
        }

        private static void CheckUnderline()
        {
            if (font.FontProps.HasFlag(FontStyle.Underline))
                font.FontProps = font.FontProps & ~FontStyle.Underline;
            else
                font.FontProps |= FontStyle.Underline;
        }

        private static void CheckItalic()
        {
            if (font.FontProps.HasFlag(FontStyle.Italic))
                font.FontProps = font.FontProps & ~FontStyle.Italic;
            else
                font.FontProps |= FontStyle.Italic;
        }

        private static void CheckBold()
        {
            if (font.FontProps.HasFlag(FontStyle.Bold))
                font.FontProps = font.FontProps & ~FontStyle.Bold;
            else
                font.FontProps |= FontStyle.Bold;
        }

        static void PrintParameters()
        {
            Console.WriteLine("Параметры надписи:\n" + font.FontProps + "\n Введите:\n 1: bold\n 2: italic\n 3: underline\n");
        }
    }
}