using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool positiveNumber = false;
            Console.WriteLine("Введите N:");
            Console.WriteLine();

            while (!positiveNumber)
            {
                if (int.TryParse(Console.ReadLine(), out int linesCount) && linesCount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    OutputStars(linesCount);
                    positiveNumber = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение!");
                    positiveNumber = false;
                }
            }

            Console.ReadKey();
        }

        static void OutputStars(int linesCount)
        {
            for (int i = 0; i < linesCount; ++i)
            {
                string str = new string('*', i + 1);
                Console.WriteLine(str);
            }
        }
    }
}
