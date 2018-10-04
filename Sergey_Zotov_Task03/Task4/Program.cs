using System;
using Library;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Init init = new Init();
            Printer printer = new Printer();
            int[,] arr = new int[10, 10];
            init.Initializing(arr);
            Console.WriteLine("Исходный массив:\n");
            printer.Print(arr);
            Console.WriteLine($"Сумма элементов, стоящих в четных позициях, равна {GetSummOFEvenPositionNumbers(arr)}");
            Console.ReadKey();
        }

        static int GetSummOFEvenPositionNumbers(int[,] Arr)
        {
            int summ = 0;
           
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if ((i + j) % 2 == 0)
                    {
                        summ = summ + Arr[i, j];
                    }
                }
            }
            return summ;
        }
    }
}
