using System;

namespace Task4
{
    class Enemies : Objects, IMoveable
    {
        // Для алгоритма ходов
        private protected Random randomPosition = new Random();

        public Enemies(string startPositionX, string startPositionY) :
            base(startPositionX, startPositionY)
        {
            X = randomPosition.Next(1, int.Parse(startPositionX));
            Y = randomPosition.Next(1, int.Parse(startPositionY));
        }

        public bool GetMove(int coordinateX, int coordinateY) => default;

        public bool IsDealtDamage() => default;

        public int MoveSpeed { set; get; }
    }
}
