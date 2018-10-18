using System;

namespace Task4
{
    class Enemy : GameObject, IMoveable
    {
        // Для алгоритма ходов
        private protected Random randomPosition = new Random();

        public Enemy(int startPositionX, int startPositionY) :
            base(startPositionX, startPositionY)
        {
            X = randomPosition.Next(1, startPositionX);
            Y = randomPosition.Next(1, startPositionY);
        }

        public bool GetMove(int coordinateX, int coordinateY) => default;

        public bool IsDealtDamage() => default;

        public void Move()
        {
            throw new NotImplementedException();
        }

        public int MoveSpeed { set; get; }
    }
}
