using System;
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
            Console.WriteLine("Введите координаты окружности, x и y соответственно");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус окружности");
            int radius = int.Parse(Console.ReadLine());
            Round round = new Round(x, y, radius);          
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
