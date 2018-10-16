using System;

namespace Task2
{
    internal class Ring
    {
        public Round inner;
        public Round outter;

        public Ring(int x, int y, double innerRadius, double outterRadius)
        {
            if (innerRadius >= outterRadius)
                throw new ArgumentException("Inner radius must be less than outter radius!");

            outter = new Round(x, y, outterRadius);
            inner = new Round(x, y, innerRadius);
        }
       
        public double RingSquare => outter.Square - inner.Square;

        public double SumOfCircumcircles => outter.LengthOfCircumcircle + inner.LengthOfCircumcircle;
    }
}
