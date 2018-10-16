namespace Task1
{
    class Line : Figure, IDrawable
    {
        public Line(int begin, int end) : base(begin, end)
        {

        }

        public string Draw()
        {
            return $"This figure is a line. This line begins at point {X} and ends at point {Y}";
        }

    }
}