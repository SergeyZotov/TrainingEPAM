using System;
namespace Task1
{
    class Round : Circle
    {
        public Round(int x, int y, double radius) : 
            base(x, y, radius)
        {

        }

        public override string Draw()
        {
            return $"This figure is a round. Its area is located inside the circle with center at ({X};{Y}).\n" +
                $"Its radius equals to {Radius}";
        }
    }    
}
