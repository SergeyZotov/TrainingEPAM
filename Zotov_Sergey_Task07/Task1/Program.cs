using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new ConsolePrinter();
            var canvas = new Canvas(printer);
            FillFigures(canvas);
            Console.WriteLine();

            foreach (var value in canvas.arrayOfFigures)
            {
                printer.Print(value);
            }

            Console.ReadKey();
        }

        static void FillFigures(Canvas canvas)
        {
            try
            {
                Console.WriteLine("Enter the beginning and the end of the line:");
                Line line = new Line(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                canvas.arrayOfFigures.Add(line);

                Console.WriteLine("Enter coordinates and radius for circle:");
                Circle circle = new Circle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()));
                canvas.arrayOfFigures.Add(circle);

                Console.WriteLine("Enter coordinates and radius for round:");
                Round round = new Round(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()));
                canvas.arrayOfFigures.Add(round);

                Console.WriteLine("Enter coordinates and inner and outter radius for round:");
                Ring ring = new Ring(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
                canvas.arrayOfFigures.Add(ring);

                Console.WriteLine("Enter the length and the width of the rectangle:");
                Rectangle rectangle = new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                canvas.arrayOfFigures.Add(rectangle);
            }
            catch (FormatException)
            {
                Console.WriteLine("You can enter only numbers!");
            }
        }
    }
}
