using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>();
            Random random = new Random();
            int k = 0;

            for (; k < random.Next(25, 100); ++k)
            {
                for (int i = k*1000; i < k*1000 + 1000 - k; ++i)
                {
                    for (int j = k*500; j < k*500 + 1000 + k; ++j)
                    {
                        list.Add(new TwoDPointWithHash(i, j).GetHashCode());
                    }
                }
            }

            var uniqValues = list.Distinct();

            Console.WriteLine();
            
            Console.WriteLine($"Процент Коллизии: {((double)uniqValues.Count()/list.Count) * 100,0}%");

            Console.ReadKey();
        }
    }
}
