using System;

namespace Task1
{
    class Ring : Figure, IDrawable
    {
        public Round outter;
        public Round inner;

        public Ring(int x, int y, double innerRadius, double outterRadius) :
            base(x, y)
        {
            if (innerRadius >= outterRadius)
                throw new ArgumentException("Inner radius must be less than outter radius!");

            outter = new Round(x, y, outterRadius);
            inner = new Round(x, y, innerRadius);
        }

        public string Draw()
        {
            return $"This figure is a ring. Its center is at point ({inner.X};{inner.Y}).\n" +
                $"Inner radius equals to {inner.Radius} and outter radius equals to {outter.Radius}";
        }
    }
}
