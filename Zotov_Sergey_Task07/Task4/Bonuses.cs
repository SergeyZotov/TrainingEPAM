using System;

namespace Task4
{
    class Bonuse : GameObject, INotMoveable
    {
        Random randomPosition = new Random();

        public Bonuse(int positionX, int positionY) : 
            base(positionX, positionY)
        {
            X = randomPosition.Next(1, positionX);
            Y = randomPosition.Next(1, positionY);
        }

        public bool IsTaken { get; set; }

        protected bool GetBonus() => default;
    }
}
