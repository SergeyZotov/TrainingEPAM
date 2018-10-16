using System;

namespace Task2
{
    public class Round
    {
        public double radius;

        public Round(int x, int y, double radius)
        {
                X = x;
                Y = y;
                Radius = radius;
        }

        public int X { set; get; }

        public int Y { set; get; }

        public double Radius
        {
            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius cannot be less than 0");

                radius = value;
            }
            get => radius;
        }

        public double Square => Math.PI * Radius * Radius; 

        public double LengthOfCircumcircle => 2 * Math.PI * Radius; 
    }       
}
