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
            List<Enemy> enemies = new List<Enemy>(_randomCountObjects.Next(3, 10));
            List<Obstacle> obstacles = new List<Obstacle>(_randomCountObjects.Next(1, 12));
            List<Bonus> bonuses = new List<Bonus>(_randomCountObjects.Next(5, 10));

            Player player = new Player();
            Console.WriteLine("Enter size of the field:");

            try
            {
                Field field = new Field(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()),
                    player, enemies, obstacles, bonuses);

                Play(field);
            }
            catch(FormatException)
            {
                Console.WriteLine("You can enter only integer numbers!");
            }


            Console.ReadKey();
        
        }

        static void Play(Field field)
        {

        }
    }
}

