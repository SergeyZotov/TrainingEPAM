using System;

namespace Task4
{
    class Bonus : GameObject, INotMoveable
    {
        Random randomPosition = new Random();

        public Bonus(int positionX, int positionY) : 
            base(positionX, positionY)
        {
            X = randomPosition.Next(1, positionX);
            Y = randomPosition.Next(1, positionY);
        }

        public bool IsTaken { get; set; }

        protected bool GetBonus() => default;
    }
}
