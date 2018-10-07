using System;

namespace Task3
{
    public class Triangle
    {
        internal readonly uint sideA;
        internal readonly uint sideB;
        internal readonly uint sideC;
        private readonly double halfPerimeter;

        public Triangle(uint sideA, uint sideB, uint sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
            halfPerimeter = (sideA + sideB + sideC) / 2;
        }

        public uint GetPerimeter() => sideA + sideB + sideC;

        public double GetSquare() => 
            Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
    }
}
