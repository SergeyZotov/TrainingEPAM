using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Rectangle : Figure
    {
        public Rectangle(string length, string width) :
            base(length, width)
        {

        }

        public override string Draw()
        {
            if (X == Y)
                return $"This figure is a square with sides equal to {X}";
            else
                return $"This figure is a rectangle with length equals to {X} and width equals to {Y}";
        }

    }
}
