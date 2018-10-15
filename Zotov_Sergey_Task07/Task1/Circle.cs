using System;

namespace Task1
{
    class Circle : Figure, IDrawable
    {
        private protected double radius;

        public Circle(string x, string y, string radius) : base(x, y)
        {
            if (!double.TryParse(radius, out this.radius) || this.radius <= 0)
                throw new ArgumentException("Radius must be an integer number and be more than 0");

            Radius = this.radius;          
        }

        internal protected double Radius
        {
            private protected set
            {
                radius = value;
            }

            get => radius;
        }

        public virtual string Draw(IDrawable circle)
        {
            return $"This figure is a circle. Center of this circle is at point ({X};{Y}). Its radius equals to {Radius}.";
        }
    }
}
