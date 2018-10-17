using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] newArr = {1, 2, 3 };

            DynamicArray<int> array = new DynamicArray<int>(newArr);

            //array.Remove(3);
            array.Add(-5);
            array.Add(3);
            array.Add(100);
            //array.Insert(-1, 2);
            array.AddRange(newArr);
            array.AddRange(newArr);
            array.Add(-34);

            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine($"Capacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");

            Console.ReadKey();
        }
    }
}
