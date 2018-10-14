using System.Collections.Generic;

namespace Task4
{
    sealed class StoneWall : Stone
    {
        List<Stone> stoneWall;

        public StoneWall(string positionX, string positionY) :
            base(positionX, positionY)
        {
            stoneWall = new List<Stone>();
        }

        internal int Length { get; set; }

    }
}
