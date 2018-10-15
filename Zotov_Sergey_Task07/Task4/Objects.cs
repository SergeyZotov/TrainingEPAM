using System;

namespace Task4
{
    abstract internal class Objects
    {
        private int x;
        private int y;
        public Objects(string coordinateX, string coordinateY)
        {
            if (!int.TryParse(coordinateX, out x) || !int.TryParse(coordinateY, out y))
            {
                throw new ArgumentException("Must be integer");
            }

            X = x;
            Y = y;
        }

        internal protected int X { private protected set; get; }
            
        internal protected int Y { private protected set; get; }
    }
}
