using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int summ = 0;

            for (int i = 3; i < 1000; ++i)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    summ = summ + i;
            }

            Console.WriteLine(summ);
            Console.ReadKey();
        }
    }
}
