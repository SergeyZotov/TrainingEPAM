using System;

namespace Task1
{
    class Figure
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
