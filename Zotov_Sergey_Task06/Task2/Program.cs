using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the coordinates X and Y, inner and outter radius:");

            Round round1 = new Round(1, -2, 10);

            Console.WriteLine(round1.LengthOfCircumcircle);

            try
            {
                Ring ring = new Ring(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

                PrintInfo(ring);
            }
            catch(FormatException)
            {
                Console.WriteLine("You must enter numbers");
            }

            Console.ReadKey();
        }

        static void PrintInfo(Ring ring)
        {
            Console.WriteLine($"\nCoordinate X:\t\t\t{ring.outter.X}\n" +
                $"Coordinate Y:\t\t\t{ring.outter.Y}\n" +
                $"Inner radius:\t\t\t{ring.inner.Radius}\n" +
                $"Outter radius:\t\t\t{ring.outter.Radius}\n" +
                $"Square of ring:\t\t\t{ring.RingSquare}\n" +
                $"Sum of both circumcircles:\t{ring.SumOfCircumcircles}");
        }
    }
}
