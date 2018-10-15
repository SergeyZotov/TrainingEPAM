namespace Task1
{
    class Round : Circle
    {

        public Round(string x, string y, string radius) : 
            base(x, y, radius)
        {

        }

        public override string Draw(IDrawable round)
        {
            return $"This figure is a round. Its area is located inside the circle with center at ({X};{Y}).\n" +
                $"Its radius equals to {Radius}";
        }
    }
}
