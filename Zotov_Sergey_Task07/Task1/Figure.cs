using System;

namespace Task1
{
    abstract class Figure
    {
        public double x;
        public double y;

        public Figure(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double X
        {
            private protected set
            {
                x = value;
            }

            get => x;
        }

        public double Y
        {
            private protected set
            {
                y = value;
            }

            get => y;
        }
    }
}
