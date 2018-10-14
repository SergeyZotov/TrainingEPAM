using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Figure //: IDrawable
    {
        private protected double x;
        private protected double y;

        public Figure( string x, string y)
        {
            if (!double.TryParse(x, out this.x) || !double.TryParse(y, out this.y))
                throw new ArgumentException("Coodrinates must be a real number!");

            X = this.x;
            Y = this.y;
        }

        public virtual string Draw()
        {
            return "This is a figure";
        }

       /* public virtual string Draw(Line line)
        {
            return $"This figure is a line. This line begins at point {X} and ends at point {Y}";
        }

        public virtual string Draw(Circle circle)
        {
            return $"This figure is a circle.Center of this circle is at point ({X},{Y}). Its radius equals to {circle.Radius}.";
        }

        public virtual string Draw(Rectangle rectangle)
        {
            if (X == Y)
                return $"This figure is a square with sides equal to {X}";
            else
                return $"This figure is a rectangle with length equals to {X} and width equals to {Y}";
        }

        public virtual string Draw(Ring ring)
        {
            return $"This figure is a ring. Its center is at point ({X};{Y}).\n" +
                $"Inner radius equals to {ring.InnerRadius} and outter radius equals to {ring.Radius}";
        }

        public virtual string Draw(Round round)
        {
            return $"This figure is a round. Its area is located inside the circle with center at ({X};{Y}).\n" +
                $"Its radius equals to {round.Radius}";
        }*/

        internal protected double X
        {
            private protected set
            {
                x = value;
            }

            get => x;
        }

        internal protected double Y
        {
            private protected set
            {
                y = value;
            }

            get => y;
        }
    }
}
