using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты и радиус");
            Round round = new Round(Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            Print(round);
            Console.ReadKey();
        }

        static void Print(Round round)
        {
            Console.WriteLine($"Координаты центра круга:\n" +
                $"x = {round.X}, y = {round.Y}\n" +
                $"Радиус окружности равен {round.Radius}\n" +
                $"Площадь круга равна {Math.Round(round.GetSquareOfCircle, 3)}\n" +
                $"Длина описанной окружности равна {Math.Round(round.GetLengthOfCircumCircle, 3)}");
        }
    }
}
