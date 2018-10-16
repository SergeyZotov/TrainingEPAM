namespace Task4
{
    class Stone : Obstacle
    {
        public Stone(int positionX, int positionY) :
            base(positionX, positionY)
        {
            IsTaken = false;
        }
    }
}
