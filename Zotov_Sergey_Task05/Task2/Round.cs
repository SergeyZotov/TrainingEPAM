using System;

namespace Task2
{
    public class Round
    {
        private double radius;

        public Round(string x, string y, string radius)
        {
            try
            {
                Y = double.Parse(y);
                X = double.Parse(x);
                Radius = double.Parse(radius);
            }
            catch (FormatException)
            {
                throw new FormatException("Координаты и радиус должны быть целым или вещественным числом");
            }
        }

        internal protected double X { private set; get; }

        internal protected double Y { private set; get; }

        internal protected double Radius
        {
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Радиус не может быть меньше нуля");

                radius = value;
            }
            get => radius;
        }

        /*internal protected void SetValueX(string x)
        {
            if (!double.TryParse(x, out this.x))
                throw new ArgumentException("Вы ввели некорректное значение");

            X = double.Parse(x);
        }

        internal protected void SetValueY(string y)
        {
            if (!double.TryParse(y, out this.y))
                throw new ArgumentException("Вы ввели некорректное значение");

            Y = double.Parse(y);
        }

        internal protected void SetValueRadius(string radius)
        {
            if (!double.TryParse(radius, out this.radius))
                throw new ArgumentException("Вы ввели некорректное значение");

            Radius = double.Parse(radius);
        }

        internal protected void SetValues(string radius, string x, string y)
        {

            try
            {
                Y = double.Parse(y);
                X = double.Parse(x);
            }
            catch (FormatException)
            {
                throw new FormatException("Координаты должны быть целым или вещественным числом");
            }

            try
            {
                Radius = double.Parse(radius);
            }
            catch (FormatException)
            {
                throw new FormatException("Радиус не может быть меньше нуля");
            }
        }*/

        internal protected double GetSquareOfCircle { get => Math.PI * Radius * Radius; }

        internal protected double GetLengthOfCircumcircle { get => 2 * Math.PI * Radius; }

    }       
}
