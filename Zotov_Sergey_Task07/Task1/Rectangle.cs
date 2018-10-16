namespace Task1
{
    class Rectangle : Figure, IDrawable
    {
        public Rectangle(int length, int width) :
            base(length, width)
        {

        }

        public string Draw()
        {
            if (X == Y)
                return $"This figure is a square with sides equal to {X}";
            else
                return $"This figure is a rectangle with length equals to {X} and width equals to {Y}";
        }

    }
}
