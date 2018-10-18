namespace Task4
{
    sealed internal class Apple : Bonus
    {
        public Apple(int positionX, int positionY) : 
            base(positionX, positionY)
        {
            
        }

        internal bool Immortality() => default;
    }
}
