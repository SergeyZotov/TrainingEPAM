namespace Task4
{
    class Tree : Obstacle
    {
        public Tree(int positionX, int positionY) :
            base(positionX, positionY)
        {
            IsTaken = false;
        }
    }
}
