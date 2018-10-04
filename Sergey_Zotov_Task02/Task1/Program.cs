using System;

namespace Sergey_Zotov_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool positiveNumber = false;
            int sideA = 0;
            int sideB = 0;

            while (!positiveNumber)
            {
                Console.WriteLine("Введите сторону a:");

                if (!Check(out sideA))
                {
                    positiveNumber = false;
                    continue;
                }
                else
                    positiveNumber = true;

                Console.WriteLine("Введите сторону b:");
                if (!Check(out sideB))
                {
                    positiveNumber = false;
                    continue;
                }
                else
                    positiveNumber = true;

                if (positiveNumber)
                    Console.WriteLine($"Площадь прямоугольника со сторонами {sideA} и {sideB} равна {ExecuteRectangleSquare(sideA, sideB)}");
                else continue;
            }
            Console.ReadKey();
        }

        static int ExecuteRectangleSquare(int a, int b)
        {
            return a * b;
        }    

        static bool Check(out int side)
        {
            try
            {
                side = int.Parse(Console.ReadLine());

                return side > 0;
            }
            catch(FormatException)
            {
                side = 0;
                return false;
            }
        }
    }
}
