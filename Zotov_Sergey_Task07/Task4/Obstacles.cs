using System;

namespace Task4
{
    class Obstacles : GameObject, INotMoveable
    {
        Random randomPosition = new Random();

        public Obstacles(int positionX, int positionY) : 
            base(positionX, positionY)
        {
            X = randomPosition.Next(1, positionX);
            Y = randomPosition.Next(1, positionY);
        }

        public bool IsTaken { get; set; }
    }
}
