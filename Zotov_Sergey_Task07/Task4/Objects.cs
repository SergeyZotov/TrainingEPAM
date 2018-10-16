using System;

namespace Task4
{
    abstract internal class GameObject
    {
        private int x;
        private int y;

        public GameObject(int coordinateX, int coordinateY)
        {
            X = x;
            Y = y;
        }

        internal protected int X { private protected set; get; }
            
        internal protected int Y { private protected set; get; }
    }
}
