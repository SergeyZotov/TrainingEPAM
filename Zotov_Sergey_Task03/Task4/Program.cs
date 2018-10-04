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
            int[,] Arr = new int[10, 10];
            init.Initializing(Arr);
            Console.WriteLine("Исходный массив:\n");
            printer.Print(Arr);
            Console.WriteLine($"Сумма элементов, стоящих в четных позициях, равна {Summ(Arr)}");
            Console.ReadKey();
        }

        static int Summ(int[,] Arr)
        {
            int summ = 0;
           
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if ((i + j) % 2 == 0)
                        summ = summ + Arr[i, j];                       
                }
            }
            return summ;
        }
    }
}
