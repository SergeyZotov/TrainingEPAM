namespace Task1
{
    class Rectangle : Figure, IDrawable
    {
        public Rectangle(string length, string width) :
            base(length, width)
        {

        }

        public string Draw(IDrawable rectangle)
        {
            if (X == Y)
                return $"This figure is a square with sides equal to {X}";
            else
                return $"This figure is a rectangle with length equals to {X} and width equals to {Y}";
        }

    }
}
