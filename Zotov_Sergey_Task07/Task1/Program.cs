using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {          
            List<Figure> figures = new List<Figure>();

            Console.WriteLine("Enter the beginning and the end of the line:");
            Line line = new Line(Console.ReadLine(), Console.ReadLine());

            Console.WriteLine("Enter coordinates and radius for circle:");
            Circle circle = new Circle(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

            Console.WriteLine("Enter coordinates and radius for round:");
            Round round = new Round(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

            Console.WriteLine("Enter coordinates and inner and outter radius for round:");
            Ring ring = new Ring(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

            figures.Add(line);
            figures.Add(circle);
            figures.Add(round);
            figures.Add(ring);

            foreach (var value in figures)
            {
                Console.WriteLine(value.Draw());
                Console.WriteLine('\n');
            }

            Console.ReadKey();
        }
        
    }
}
