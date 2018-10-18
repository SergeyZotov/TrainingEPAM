namespace Task3
{
    class ArithmeticalProgression : ISeries, IIndexable
    {
        public double difference;
        public int currentIndex;
        public double start;

        public ArithmeticalProgression(int firstMember, int step)
        {
            start = firstMember;

            difference = step;
        }

        public double this[int index]
        {
            get
            {
                return this[index];
            }
        }

        public double GetCurrent()
        {
            return start + ((currentIndex - 1) * difference);
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
