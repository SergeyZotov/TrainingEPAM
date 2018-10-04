using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N:");
            bool positiveNumber = false;

            while (!positiveNumber)
            {
                if (int.TryParse(Console.ReadLine(), out int figuresCount) && figuresCount > 0)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    positiveNumber = true;
                    for (int i = 0; i < figuresCount + 1; ++i)
                        OutputTriangles(i, figuresCount);
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение!");
                    positiveNumber = false;
                }

            }
            

            Console.ReadKey();
        }
        static void OutputTriangles(int starsCount, int indent)
        {

            int helper = starsCount;
            for (int i = 0; i < starsCount; ++i)
            {
                PrintSpaces(indent--);
                Console.Write('*');
                string str = new string('*', starsCount - helper + 2 * i);
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
