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

            int[] newArr1 = new int[15];

            DynamicArray<int> array = new DynamicArray<int>(5);

            for (int i = 0; i < array.Capacity; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nAfter initialization with constructor");
            Console.WriteLine($"\nCapacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");

            array.AddRange(newArr);

            Console.WriteLine();
            for (int i = 0; i < array.Capacity; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine($"\nAfter AddRange(newArr), newArr.Length = {newArr.Length};");
            Console.WriteLine($"\nCapacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");
            
            array.Add(-1);

            Console.WriteLine();
            for (int i = 0; i < array.Capacity; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nAfter adding to the end \'-1\'");
            Console.WriteLine($"\nCapacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");

            array.Insert(-4, 2);
            Console.WriteLine();
            for (int i = 0; i < array.Capacity; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nAfter adding \'-4\' at position 2");
            Console.WriteLine($"\nCapacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");

            array.Insert(-4, 6);
            Console.WriteLine();
            for (int i = 0; i < array.Capacity; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nAfter adding \'-4\' at position 6");
            Console.WriteLine($"\nCapacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");

            if (array.Remove(-40))
            {
                Console.WriteLine();
                for (int i = 0; i < array.Capacity; ++i)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine("\nAfter remove \'-40\'");
                Console.WriteLine($"\nCapacity equals to {array.Capacity}");
                Console.WriteLine($"Length equals to {array.Length}");
            }

            if (array.Remove(-4))
            {
                Console.WriteLine();
                for (int i = 0; i < array.Length; ++i)
                {
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine("\nAfter remove \'-4\'");
                Console.WriteLine($"\nCapacity equals to {array.Capacity}");
                Console.WriteLine($"Length equals to {array.Length}");
            }

            array.AddRange(newArr1);
            Console.WriteLine();
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nAfter adding big array");
            Console.WriteLine($"\nCapacity equals to {array.Capacity}");
            Console.WriteLine($"Length equals to {array.Length}");

            Console.ReadKey();
        }
    }
}
