using System;

namespace Task1
{
    class Circle : Figure, IDrawable
    {
        public double radius;

        public Circle(int x, int y, double radius) : base(x, y)
        {
            Radius = radius;          
        }

        public double Radius
        {
            private protected set
            {
                if (value < 0)
                    throw new ArgumentException("Radius must be more than 0");

                radius = value;
            }

            get => radius;
        }

        public virtual string Draw()
        {
            return $"This figure is a circle. Center of this circle is at point ({X};{Y}). Its radius equals to {Radius}.";
        }
    }
}
