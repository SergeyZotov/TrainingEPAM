using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first member, denominator " +
                "and number of your progression:");
            GeometricProgression geometricProgression = new GeometricProgression(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            PrintSeries(geometricProgression, geometricProgression.Count);
            Console.ReadKey();
        }

        static void PrintSeries(ISeries mySeries, int count)
        {
            while (mySeries.MoveNext() && count != 0)
            {
                Console.Write($"{mySeries.GetCurrent()}  ");
                count--;
            }
        }
    }
}
