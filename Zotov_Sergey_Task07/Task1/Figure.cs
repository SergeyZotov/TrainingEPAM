using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Figure : IDrawable
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
            return "this is a figure";
        }

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
