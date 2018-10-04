using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool positiveNumber = false;
            Console.WriteLine("Введите N:");
            while (!positiveNumber)
            {
                if (int.TryParse(Console.ReadLine(), out int linesCount) && linesCount > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    OutputTriangle (linesCount);
                    positiveNumber = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение!");
                    positiveNumber = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.ReadKey();
        }

        static void OutputTriangle(int linesCount)
        {
            int helper = linesCount;

            for (int i = 0; i < linesCount; ++ i)
            {
                PrintSpaces(helper--);
                string str = new string('*', linesCount - helper + i);
                Console.WriteLine(str);
            }
        }

        static void PrintSpaces(int count)
        {
            for (int i = 0; i < count; ++i)
                Console.Write(' ');
        }
    }
}
