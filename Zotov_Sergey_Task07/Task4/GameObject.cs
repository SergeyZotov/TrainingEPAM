using System;

namespace Task4
{
    abstract internal class GameObject
    {
        private int x;
        private int y;

        public GameObject(int coordinateX, int coordinateY)
        {
            X = coordinateX;
            Y = coordinateY;
        }

        protected int X
        {
            set
            {
                value = x;
            }

            get => x;
        }

        protected int Y
        {
            set
            {
                value = y;
            }

            get => y;
        }
    }
}
