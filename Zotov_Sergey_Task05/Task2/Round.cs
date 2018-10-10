using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Round
    {
        internal double X
        {
            set
            {
                X = value;
            }
            get
            {
                return X;
            }
        }
        
        internal double Y
        {
            set
            {
                Y = value;
            }
            get
            {
                return Y;
            }
        }
        
        internal int Radius
        {
            set
            {
                if (Radius < 0)
                    throw new ArgumentException("Радиус не может быть меньше 0");

                Radius = value;
            }
            get
            {
                return Radius;
            }
        }

        public Round(double x, double y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        internal double GetSquareOfCircle { get => Math.PI * Radius * Radius; }

        internal double GetLengthOfCircumCircle { get => 2 * Math.PI * Radius; }

    }       
}
