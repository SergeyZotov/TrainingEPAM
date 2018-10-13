using System;

namespace Task2
{
    internal class Ring : Round
    {
        private protected double innerRadius;

        public Ring(string x, string y, string innerRadius, string outterRadius) : 
            base(x, y, outterRadius)
        {
            if(!double.TryParse(innerRadius, out this.innerRadius))
            {
                throw new FormatException("Inner radius must be a real number!");
            }
            else
                InnerRadius = this.innerRadius;
        }

        internal protected double InnerRadius
        {
            private protected set
            {
                if (value < 0 || value >= radius)
                    throw new ArgumentException("Inner radius must be more than 0 and less than outter radius!");

                innerRadius = value;
            }
            get => innerRadius;
        }
        private new double GetSquareOfCircle => Math.PI* InnerRadius * InnerRadius;

        private new double GetLengthOfCircumcircle => 2 * Math.PI * InnerRadius;

        internal protected double RingSquare => base.GetSquareOfCircle - GetSquareOfCircle;

        internal protected double SumOfCircumcircles => base.GetLengthOfCircumcircle + GetLengthOfCircumcircle;
    }
}
