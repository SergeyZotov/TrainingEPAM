using System;
using Library;

namespace Zotov_Sergey_Task03
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
            Console.WriteLine($"Максимальное значение массива: {MaxValue(arr)}");
            Console.WriteLine($"\nМинимальное значение массива: {MinValue(arr)}");
            Sorting(arr);
            Console.WriteLine();
            Console.WriteLine($"\nОтсортированный массив:\n");
            printer.Print(arr);
            Console.ReadKey();

        }
        static int MaxValue(int[] Arr)
        {
            int min = int.MinValue;

            foreach (int value in Arr)
            {
                if (value > min)
                    min = value;
            }

            return min;
        }

        static int MinValue(int[] Arr)
        {
            int max = int.MaxValue;

            foreach (int value in Arr)
            {
                if (value < max)
                    max = value;
            }

            return max;
        }

        static void Sorting(int[] Arr)
        {
            int temp = 0;
            for (int i = 0; i < 10; ++i)
                for (int j = i + 1; j < 10; ++j)
                {
                    if (Arr[i] > Arr[j])
                    {
                        temp = Arr[i];
                        Arr[i] = Arr[j];
                        Arr[j] = temp;
                    }
                }
        }
    }
}
