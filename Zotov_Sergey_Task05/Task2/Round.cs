using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Round
    {
        internal readonly int x;
        internal readonly int y;
        internal uint radius;

        public Round(int x, int y, uint radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        internal double GetSquareOfCircle { get => Math.PI * radius * radius; }

        internal double GetLengthOfCircumCircle { get => 2 * Math.PI * radius; }

    }       
}
