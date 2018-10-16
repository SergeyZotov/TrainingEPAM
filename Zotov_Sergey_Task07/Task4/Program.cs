using System;
using System.Collections.Generic;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random _randomPosition = new Random();
            Random _randomCountObjects = new Random();
            List<Enemies> enemies = new List<Enemies>(_randomCountObjects.Next(3, 10));
            List<Obstacles> obstacles = new List<Obstacles>(_randomCountObjects.Next(1, 12));
            List<Bonuse> bonuses = new List<Bonuse>(_randomCountObjects.Next(5, 10));

            Player player = new Player();
            Console.WriteLine("Enter size of the field:");

            try
            {
                Field field = new Field(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                    player, enemies, obstacles, bonuses);

                FillingCells(ref field);
                Play(field);
            }
            catch(FormatException)
            {
                Console.WriteLine("You can enter only integer numbers!");
            }


            Console.ReadKey();
        }

        private static void FillingCells(ref Field field)
        {
            if (field.cells[0, 1] != new Tuple<int, int>(0, 1))
            {
                for (int i = 0; i < field.Width; ++i)
                {
                    for (int j = 0; j < field.Height; ++j)
                    {
                        field.cells[i, j] = new Tuple<int, int>(i, j);
                    }
                }
            }
            else
                Console.WriteLine("THe field is already existing");
        }

        static void Play(Field field)
        {

        }
    }
}

