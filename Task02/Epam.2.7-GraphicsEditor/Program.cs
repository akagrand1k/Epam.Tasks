using Epam._2._7_GraphicsEditor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam._2._7_GraphicsEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would  figure you like draw? Input next name:\n"
                + "Line\n" + "Circle\n" + "Rectangle\n" + "Round\n" + "Ring\n");
            string s = Console.ReadLine();
            switch (s)
            {
                case "Line":
                    CreateLine();
                    break;

                case "Circle":
                    CreateCircle();
                    break;

                case "Rectangle":
                    CreateRectangle();
                    break;

                case "Round":
                    CreateRound();
                    break;

                case "Ring":
                    CreateRing();
                    break;

                default:

                    break;
            }

            Console.ReadKey();
        }
        

        private static void CreateRing()
        {
            Console.WriteLine("Enter inner and outer radius");
            Ring r = new Ring(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            r.Draw();
        }

        private static void CreateRound()
        {
            Console.WriteLine("Enter round radius");
            Round r = new Round(double.Parse(Console.ReadLine()));
            r.Draw();
        }

        private static void CreateRectangle()
        {
            Console.WriteLine("Enter A and B side");
            Rectangle r = new Rectangle(int.Parse(Console.ReadLine()),int.Parse(Console.ReadLine()));
            r.Draw();
        }

        private static void CreateCircle()
        {
            Console.WriteLine("Enter radius");
            Circle c = new Circle(double.Parse(Console.ReadLine()));
            c.Draw();
        }

        private static void CreateLine()
        {
            Console.WriteLine("Enter point x,y");
            Line l = new Line(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            l.Draw();
        }
    }
}