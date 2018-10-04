using System;
using Library;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Init init = new Init();
            Printer printer = new Printer();
            int[, ,] Arr = new int[3, 5, 5];
            init.Initializing(Arr);
            Console.WriteLine("Исходный массив:");
            printer.Print(Arr);
            RemovePositive(Arr);
            Console.WriteLine("Измененный массив:");
            printer.Print(Arr);
            Console.ReadKey();
        }

        static void RemovePositive(int[, ,] Arr)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    for (int k = 0; k < 5; ++k)
                    {
                        if (Arr[i, j, k] > 0)
                            Arr[i, j, k] = 0;
                    }
                }
            }
        }
    }
}
