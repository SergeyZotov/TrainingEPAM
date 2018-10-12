using System;

namespace Task3
{
    public class Triangle
    {
        public Triangle(string sideA, string sideB, string sideC)
        {
            try
            {
                SideA = int.Parse(sideA);
                SideB = int.Parse(sideB);
                SideC = int.Parse(sideC);

                if (SideA <= 0 || SideB <= 0 || SideC <= 0)
                    throw new Exception("У треугольника не может быть длина сторон меньше 0");

                if (((SideA + SideB) <= SideC) && ((SideB + SideC) <= SideA) && ((SideA + SideC) <= SideB))
                    throw new ArgumentException("Неправильное соотношение сторон, такого треугольника не существует");
            }
            catch (FormatException)
            {
                throw new FormatException("Сторона не может являться не целым числом");
            }
        }

        internal protected int SideA { get; private set; }
        internal protected int SideB { get; private set; }
        internal protected int SideC { get; private set; }

        public int GetPerimeter() => SideA + SideB + SideC;

        public double GetSquare()
        {   
            double halfPerimeter = (SideA + SideB + SideC) / 2.0; 

            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }

    }
}
