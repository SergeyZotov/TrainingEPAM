namespace Task4
{
    sealed internal class Apples : Bonuses
    {
        public Apples(string positionX, string positionY) : 
            base(positionX, positionY)
        {
            
        }

        internal bool Immortality() => default;
    }
}
