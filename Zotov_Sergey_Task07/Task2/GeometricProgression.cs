using System;

namespace Task2
{
    class GeometricProgression : ISeries
    {
        private double denominatorOfProgression;
        private int currentIndex;
        private double start;

        public GeometricProgression(string start, string denominatorOfProgression)
        {
            if (!double.TryParse(start, out this.start) || 
                !double.TryParse(denominatorOfProgression, out this.denominatorOfProgression))
            {
                throw new ArgumentException("The first member and denominator of progression " +
                    "cannot be equal to 0");
            }

            Start = this.start;
            DenominatorOfProgression = this.denominatorOfProgression;
        }

        internal protected double Start
        {
            private set
            {
                if (value == 0)
                    throw new ArgumentException("The first member of sequence cannot be equals to 0!");

                start = value;
            }

            get => start;
        }

        internal protected double DenominatorOfProgression
        {
            private set
            {
                if (value == 0)
                    throw new ArgumentException("The denominator of progression of sequence cannot be equals to 0!");

                denominatorOfProgression = value;
            }

            get => denominatorOfProgression;
        }

        public double GetCurrent()
        {
            return start * Math.Pow(denominatorOfProgression, currentIndex - 1);
        }

        public bool MoveNext()
        {
            currentIndex++;
            return true;
        }

        public void Reset()
        {
            currentIndex = 1;
        }


    }
}
