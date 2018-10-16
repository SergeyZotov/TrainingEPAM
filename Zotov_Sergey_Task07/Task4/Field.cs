using System;
using System.Collections.Generic;

namespace Task4
{
    sealed class Field : GameObject
    {
        internal int width;
        internal int height;

        public Field(int width, int height, Player player, List<Enemy> enemies, 
            List<Obstacle> obstacles, List<Bonus> bonuses) : 
            base(width, height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Must be positive!");

            InitializationOfObjects initializationOfObjects = new InitializationOfObjects(ref player,
                ref enemies, ref bonuses, ref obstacles, height, width);

            Width = width;
            Height = height;
        }

        internal int Width
        {
            private set
            {
                width = value;
            }
            get => width;
        }

        internal int Height
        {
            private set
            {
                Height = value;
            }

            get => Height;
        }
    }
}
