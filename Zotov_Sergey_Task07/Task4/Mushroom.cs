namespace Task4
{
    class Mushroom : Bonuses
    {
        public Mushroom(string positionX, string positionY) :
            base(positionX, positionY)
        {

        }

        internal int GetAdditionalLife()
        {
            return default;
        }
    }
}
