using System;

namespace Task4
{
    class Bonuses : Objects, INotMoveable
    {
        Random randomPosition = new Random();

        public Bonuses(string positionX, string positionY) : 
            base(positionX, positionY)
        {
            X = randomPosition.Next(1, int.Parse(positionX));
            Y = randomPosition.Next(1, int.Parse(positionY));
        }

        public bool IsTaken { get; set; }

        protected bool GetBonus() => default;
    }
}
