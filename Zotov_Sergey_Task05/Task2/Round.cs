using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Round
    {
        private double radius;
        private double x;
        private double y;

        public Round(string x, string y, string radius)
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

        }
        
        internal protected double X
        {
            private set
            {
                x = value;
                /* if (!double.TryParse(value.ToString(), out value))
                     throw new ArgumentException("Координаты должны быть целым или вещественным числом");

                 x = value;*/
            }

            get => x;
        }

        internal protected double Y
        {
            private set
            {
                y = value;

                /*if (!double.TryParse(value.ToString(), out value))
                    throw new ArgumentException("Координаты должны быть целым или вещественным числом");

                y = value;*/
            }

            get => y;
        }

        internal protected double Radius
        {
            private set
            {

                radius = value;

                /*if (value < 0)
                    throw new ArgumentException("Радиус не может быть меньше нуля");

                radius = value;*/
            }
            get => radius;
        }

        internal protected void SetValueX(string x)
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

        /*internal protected void SetValues(string radius, string x, string y)
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

        internal protected double GetLengthOfCircumCircle { get => 2 * Math.PI * Radius; }

    }       
}
