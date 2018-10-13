using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Ring : Round
    {
        private protected double innerRadius;

        public Ring(string x, string y, string innerRadius, string outterRadius) :
            base(x, y, outterRadius)
        {
            if (!double.TryParse(innerRadius, out this.innerRadius) || this.innerRadius <= 0)
            {
                throw new ArgumentException("Radius must be an integer number, be more than 0 and less than outter radius");
            }

            InnerRadius = this.innerRadius;
        }

        internal protected double InnerRadius
        {
            private protected set
            {
                if (value >= Radius)
                    throw new ArgumentException("");

                innerRadius = value;
            }

            get => innerRadius;
        }
    }
}
