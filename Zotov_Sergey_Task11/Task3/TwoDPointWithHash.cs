using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class TwoDPointWithHash : TwoDPoint
    {
        public TwoDPointWithHash(int x, int y) : base(x, y)
        { }

        /* public override int GetHashCode()
         {
             return x ^ y; // ^ выполняет операцию логического исключающего XOR побитно

             // в чем тут проблема?
         }*/

        public override int GetHashCode()
        {
            return Tuple.Create(x, y).GetHashCode();
        }
    }
}
