using System.Collections.Generic;

namespace Task4
{
    sealed class StoneWall : Stone
    {
        List<Stone> stoneWall;

        public StoneWall(int positionX, int positionY) :
            base(positionX, positionY)
        {
            stoneWall = new List<Stone>();
            IsTaken = false;
        }

        internal int Length { get; set; }
    }
}
