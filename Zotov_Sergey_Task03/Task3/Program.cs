using System;
using Library;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Init init = new Init();
            Printer printer = new Printer();
            int[] Arr = new int[10];
            init.Initializing(Arr);
            Console.WriteLine("Исходный массив:\n");
            printer.Print(Arr);
            Console.WriteLine($"Сумма неотрицательных элементов равна {Summ(Arr)}");
            Console.ReadKey();
        }

        static int Summ(int[] Arr)
        {
            int summ = 0;

            foreach(int value in Arr)
            {
                if (value >= 0)
                    summ += value;
            }

            return summ;
        }
    }
}
