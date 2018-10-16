using System;

namespace Task2
{
    class GeometricProgression : ISeries
    {
        public double denominatorOfProgression;
        public int currentIndex;
        public double start;

        public GeometricProgression(double start, double denominatorOfProgression)
        {
            Start = start;
            DenominatorOfProgression = denominatorOfProgression;
        }

        public double Start
        {
            private set
            {
                if (value == 0)
                    throw new ArgumentException("The first member of sequence cannot be equals to 0!");

                start = value;
            }

            get => start;
        }

        public double DenominatorOfProgression
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
