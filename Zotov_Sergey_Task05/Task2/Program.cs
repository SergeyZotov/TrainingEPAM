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
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите радиус окружности");
            uint radius = uint.Parse(Console.ReadLine());
            Round round = new Round(x, y, radius);          
            Print(round);
            Console.ReadKey();
        }

        static void Print(Round round)
        {
            Console.WriteLine($"Координаты центра круга:\n" +
                $"x = {round.x}, y = {round.y}\n" +
                $"Радиус окружности равен {round.radius}\n" +
                $"Площадь круга равна {Math.Round(round.GetSquareOfCircle, 3)}\n" +
                $"Длина описанной окружности равна {Math.Round(round.GetLengthOfCircumCircle, 3)}");
        }
    }
}
