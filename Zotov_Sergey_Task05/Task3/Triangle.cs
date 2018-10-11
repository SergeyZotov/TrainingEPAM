using System;

namespace Task3
{
    public class Triangle
    {
        private protected double halfPerimeter;

        public Triangle(string sideA, string sideB, string sideC)
        {
            try
            {
                SideA = int.Parse(sideA);
                SideB = int.Parse(sideB);
                SideC = int.Parse(sideC);

                if (SideA <= 0 || SideB <= 0 || SideC <= 0)
                    throw new FormatException();

                if (((SideA + SideB) <= SideC) || ((SideB + SideC) <= SideA) || ((SideA + SideC) <= SideB))
                    throw new ArgumentException("Неправильное соотношение сторон, такого треугольника не существует");
            }
            catch (FormatException)
            {
                throw new FormatException("Сторона не может являться не целым числом или быть меньше или равна 0");
            }

            halfPerimeter = (SideA + SideB + SideC) / 2.0;
        }

        internal protected int SideA { get; private set; }
        internal protected int SideB { get; private set; }
        internal protected int SideC { get; private set; }

        public int GetPerimeter() => SideA + SideB + SideC;

        public double GetSquare() => 
            Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
    }
}
