using System;

namespace Task2
{
    public class Round
    {
        private protected double radius;

        public Round(string x, string y, string radius)
        {
            try
            {
                Y = double.Parse(y);
                X = double.Parse(x);
                Radius = double.Parse(radius);
            }
            catch (FormatException)
            {
                throw new FormatException("Координаты и радиус должны быть целым или вещественным числом");
            }
        }

        internal protected double X { private set; get; }

        internal protected double Y { private set; get; }

        internal protected double Radius
        {
            private protected set
            {
                if (value < 0)
                    throw new ArgumentException("Радиус не может быть меньше нуля");

                radius = value;
            }
            get => radius;
        }

        internal protected double GetSquareOfCircle { get => Math.PI * Radius * Radius; }

        internal protected double GetLengthOfCircumcircle { get => 2 * Math.PI * Radius; }

    }       
}
