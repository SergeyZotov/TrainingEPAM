using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class GeometricProgression : ISeries
    {
        private double denominatorOfProgression;
        private int currentIndex;
        private double start;
        private int count;

        public GeometricProgression(string start, string denominatorOfProgression, string count)
        {
            if (!double.TryParse(start, out this.start) || 
                !double.TryParse(denominatorOfProgression, out this.denominatorOfProgression))
            {
                throw new ArgumentException("The first member and denominator of progression " +
                    "cannot be equal to 0");
            }

            if (!int.TryParse(count, out this.count) || this.count < 1)
            {
                throw new ArgumentException("The count of your sequence cannot be less than 1 and must be integer!");
            }

            Start = this.start;
            DenominatorOfProgression = this.denominatorOfProgression;
            Count = this.count;
        }

        internal protected int Count
        {
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Count of your sequence cannot be less than 1 ");

                count = value;
            }

            get => count;
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
            currentIndex = 2;
        }


    }
}
