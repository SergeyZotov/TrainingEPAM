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
            int[] arr = new int[10];
            init.Initializing(arr);
            Console.WriteLine("Исходный массив:\n");
            printer.Print(arr);
            Console.WriteLine($"Сумма неотрицательных элементов равна {GetSumOfPosiveNumbers(arr)}");
            Console.ReadKey();
        }

        static int GetSumOfPosiveNumbers(int[] Arr)
        {
            int summ = 0;

            foreach(int value in Arr)
            {
                if (value >= 0)
                {
                    summ += value;
                }
            }

            return summ;
        }
    }
}
