using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            ISeries progression = new ArithmeticalProgression(2, 2);
            Console.WriteLine("Progression:");
            PrintSeries(progression as IIndexable);

            ISeries list = new List(new double[] { 5, 8, 6, 3, 1 });
            Console.WriteLine("\nList:");
            PrintSeries(list as IIndexable);

            Console.ReadKey();
        }

        static void PrintSeries(IIndexable mySeries)
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
