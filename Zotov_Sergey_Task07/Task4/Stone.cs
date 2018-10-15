namespace Task4
{
    class Stone : Obstacles
    {
        public Stone(string positionX, string positionY) :
            base(positionX, positionY)
        {
            IsTaken = false;
        }
    }
}
