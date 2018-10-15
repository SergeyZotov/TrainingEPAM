namespace Task1
{
    class Line : Figure, IDrawable
    {
        public Line(string begin, string end) : base(begin, end)
        {

        }

        public string Draw(IDrawable line)
        {
            return $"This figure is a line. This line begins at point {X} and ends at point {Y}";
        }

    }
}