using System;

namespace Task2
{
    public class Round
    {
        private protected double radius;
        private protected double x;
        private protected double y;

        public Round(string x, string y, string radius)
        {
            if (!double.TryParse(x, out this.x) || !double.TryParse(y, out this.y) ||
                !double.TryParse(radius, out this.radius))
            {
                throw new FormatException("Coordinates and radius must be positive numbers");
            }
            else
            {
                X = this.x;
                Y = this.y;
                Radius = this.radius;
            }
        }

        internal protected double X { private protected set; get; }

        internal protected double Y { private protected set; get; }

        internal protected double Radius
        {
            private protected set
            {
                if (value < 0)
                    throw new ArgumentException("Radius cannot be less than 0");

                radius = value;
            }
            get => radius;
        }

        internal protected double GetSquareOfCircle => Math.PI * Radius * Radius; 

        internal protected double GetLengthOfCircumcircle => 2 * Math.PI * Radius; 
    }       
}
