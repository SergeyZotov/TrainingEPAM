namespace Task4
{
    class Tree : Obstacles
    {
        public Tree(string positionX, string positionY) :
            base(positionX, positionY)
        {
            IsTaken = false;
        }
    }
}
