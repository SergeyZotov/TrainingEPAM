using System;

namespace Task4
{
    class Enemies : Objects, IMoveable
    {
        // Для алгоритма ходов
        Random randomPosition = new Random();

        public Enemies(string startPositionX, string startPositionY) :
            base(startPositionX, startPositionY)
        {
            X = randomPosition.Next(1, int.Parse(startPositionX));
            Y = randomPosition.Next(1, int.Parse(startPositionY));
        }

        public bool GetMove(int coordinateX, int coordinateY)
        {
            return default;
        }

        public double Damage
        {
            set; get;
        }

        public int Lives
        {
            set; get;
        }

        public bool TakeDamage(int playerDamage)
        {
            return default;
        }

        public bool IsDealtDamage(int myDamage)
        {
            return default;
        }

        public int MoveSpeed
        {
            set;
            get;
        }
    }
}
