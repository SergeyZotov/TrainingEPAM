using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Circle : Figure
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
    }
}
