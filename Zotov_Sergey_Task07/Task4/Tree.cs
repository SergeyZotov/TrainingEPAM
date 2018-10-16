namespace Task4
{
    class Tree : Obstacles
    {
        public Tree(int positionX, int positionY) :
            base(positionX, positionY)
        {
            IsTaken = false;
        }
    }
}
