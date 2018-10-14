namespace Task4
{
    sealed internal class Cherry : Bonuses
    {
        public Cherry(string positionX, string positionY) : 
            base(positionX, positionY)
        {

        }

        internal double GetIncreasedDamage()
        {
            return default;
        }
    }
}
