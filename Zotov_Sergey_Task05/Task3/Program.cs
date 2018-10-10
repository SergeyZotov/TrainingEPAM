using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны треугольника.");
            Triangle triangle = new Triangle(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            Print(triangle);
            Console.ReadKey();
        }

        static void Print(Triangle triangle)
        {
            Console.WriteLine($"Периметр треугольника со сторонами {triangle.SideA}, " +
                $"{triangle.SideB}, {triangle.SideC} равен {triangle.GetPerimeter()}.\n" +
                $"Площадь этого треугольника равна {triangle.GetSquare()}");
        }
    }
}
