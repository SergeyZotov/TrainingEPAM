using System;

namespace Task4
{
    class Obstacles : Objects, INotMoveable
    {
        Random randomPosition = new Random();

        public Obstacles(string positionX, string positionY) : 
            base(positionX, positionY)
        {
            X = randomPosition.Next(1, int.Parse(positionX));
            Y = randomPosition.Next(1, int.Parse(positionY));
        }

        public bool IsTaken()
        {
            return default;
        }
    }
}
