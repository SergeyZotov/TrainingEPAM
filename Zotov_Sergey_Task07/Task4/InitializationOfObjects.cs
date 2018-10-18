using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class InitializationOfObjects
    {
        static Random random = new Random();

        public InitializationOfObjects(ref Player player, ref List<Enemy> enemies, ref List<Bonus> bonuses, ref List<Obstacle> obstacles, int fieldHeight, int fieldWidth)
        {
            player = new Player();

            int[,] arrayOfCoordinstes = new int[2, 7];

            int height = fieldHeight;
            int width = fieldWidth;
            //
            //Заполнение матрицы с координатами
            //
            for (int j = 0; j < 7; j++)
            {
                arrayOfCoordinstes[0, j] = random.Next(1, height);
            }

            for (int j = 0; j < 7; j++)
            {
                arrayOfCoordinstes[1, j] = random.Next(1, height);
            }
            //
            //
            //
            for (int i = 0; i < random.Next(1, 3); ++i)
            {
                bonuses.Add(new Apple (random.Next(1, height), random.Next(1, width)));
            }

            for (int i = 0; i < random.Next(1, 3); ++i)
            {
                bonuses.Add(new Cherry(random.Next(1, height), random.Next(1, width)));
            }

            for (int i = 0; i < random.Next(1, 10); ++i)
            {
                enemies.Add(new Bear(random.Next(1, height), random.Next(1, width)));
            }

            for (int i = 0; i < random.Next(1, 10); ++i)
            {
                enemies.Add(new Werewolf(random.Next(1, height), random.Next(1, width)));
            }

            for (int i = 0; i < random.Next(1, 10); ++i)
            {
                enemies.Add(new ClawsOfDeath(random.Next(1, height), random.Next(1, width)));
            }

            for (int i = 0; i < random.Next(1, 10); ++i)
            {
                obstacles.Add(new Tree(random.Next(1, height), random.Next(1, width)));
            }

            for (int i = 0; i < random.Next(1, 10); ++i)
            {
                obstacles.Add(new Stone(random.Next(1, height), random.Next(1, width)));
            }
        }
    }
}
