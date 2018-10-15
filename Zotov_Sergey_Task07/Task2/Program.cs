using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first member, denominator ");
            GeometricProgression geometricProgression = new GeometricProgression(Console.ReadLine(), Console.ReadLine());
            PrintSeries(geometricProgression);
            Console.ReadKey();
        }

        static void PrintSeries(ISeries mySeries)
        {
            mySeries.Reset();

            for (int i = 0; i < 10; ++i)
            {
                Console.Write(mySeries.GetCurrent() + " ");
                mySeries.MoveNext();
            }
        }
    }
}
