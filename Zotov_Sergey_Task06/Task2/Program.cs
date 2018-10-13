using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the coordinates X and Y, inner and outter radius:");
            Ring ring = new Ring(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

            PrintInfo(ring);
            Console.ReadKey();
        }

        static void PrintInfo(Ring ring)
        {
            Console.WriteLine($"\nCoordinate X:\t\t\t{ring.X}\n" +
                $"Coordinate Y:\t\t\t{ring.Y}\n" +
                $"Inner radius:\t\t\t{ring.InnerRadius}\n" +
                $"Outter radius:\t\t\t{ring.Radius}\n" +
                $"Square of ring:\t\t\t{ring.RingSquare}\n" +
                $"Sum of both circumcircles:\t{ring.SumOfCircumcircles}");
        }
    }
}
