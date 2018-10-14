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
            figures.Add(line);

            Console.WriteLine("Enter coordinates and radius for circle:");
            Circle circle = new Circle(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            figures.Add(circle);

            Console.WriteLine("Enter coordinates and radius for round:");
            Round round = new Round(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            figures.Add(round);

            Console.WriteLine("Enter coordinates and inner and outter radius for round:");
            Ring ring = new Ring(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            figures.Add(ring);

            Console.WriteLine("Enter the length and the width of the rectangle:");
            Rectangle rectangle = new Rectangle(Console.ReadLine(), Console.ReadLine());
            figures.Add(rectangle);

            foreach (Figure value in figures)
            {
                Console.WriteLine(value.Draw());
                Console.WriteLine('\n');
            }

            Console.ReadKey();
        }
        
    }
}
