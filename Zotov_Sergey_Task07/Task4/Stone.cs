namespace Task4
{
    class Stone : Obstacles
    {
        public Stone(int positionX, int positionY) :
            base(positionX, positionY)
        {
            IsTaken = false;
        }
    }
}
