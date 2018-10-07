using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны треугольника.");
            uint sideA = uint.Parse(Console.ReadLine());
            uint sideB = uint.Parse(Console.ReadLine());
            uint sideC = uint.Parse(Console.ReadLine());
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            Print(triangle);
            Console.ReadKey();
        }

        static void Print(Triangle triangle)
        {
            Console.WriteLine($"Периметр треугольника со сторонами {triangle.sideA}, " +
                $"{triangle.sideB}, {triangle.sideC} равен {triangle.GetPerimeter()}.\n" +
                $"Площадь этого треугольника равна {triangle.GetSquare()}");
        }
    }
}
