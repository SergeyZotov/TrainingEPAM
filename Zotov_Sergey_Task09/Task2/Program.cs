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
            List<int> list = new List<int>
            {
                -12,
                124
            };

            DynamicArray<int> vs = new DynamicArray<int>(list);

            Random random = new Random();

            foreach(var value in vs)
            {
                vs.Add(random.Next(-10, 10));
            }

            foreach(var value in vs)
            {
                Console.WriteLine(value);
            }

            Console.ReadKey();
            
        }
    }
}
