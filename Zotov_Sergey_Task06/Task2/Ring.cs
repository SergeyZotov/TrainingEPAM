using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Ring : Round
    {
        private protected double innerRadius;

        public Ring(string x, string y, string innerRadius, string outterRadius) : base(x, y, outterRadius)
        {
            X = double.Parse(x);
            Y = double.Parse(y);
            InnerRadius = double.Parse(innerRadius);
            Radius = double.Parse(outterRadius);
        }

        internal protected double InnerRadius
        {
            private protected set
            {
                if (value < 0 || value >= radius)
                    throw new ArgumentException("Радиус не может быть меньше нуля");

                innerRadius = value;
            }
            get => innerRadius;
        }
    }
}
