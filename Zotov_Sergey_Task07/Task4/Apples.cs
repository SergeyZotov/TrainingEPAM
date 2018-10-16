namespace Task4
{
    sealed internal class Apples : Bonuse
    {
        public Apples(int positionX, int positionY) : 
            base(positionX, positionY)
        {
            
        }

        internal bool Immortality() => default;
    }
}
