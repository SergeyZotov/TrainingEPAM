using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(15);

            list.Add(-12);
            DynamicArray<int> vs = new DynamicArray<int>(list);

            for (int i = 0; i < 5; ++i)
                vs.Add(i);

            foreach(var value in vs)
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
            
        }
    }
}
