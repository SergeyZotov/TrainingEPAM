using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first member, denominator ");

            try
            {
                GeometricProgression geometricProgression = new GeometricProgression(double.Parse(Console.ReadLine()),
                    double.Parse(Console.ReadLine()));

                PrintSeries(geometricProgression);
            }
            catch(FormatException)
            {
                Console.WriteLine("You can enter only numbers");
            }


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
