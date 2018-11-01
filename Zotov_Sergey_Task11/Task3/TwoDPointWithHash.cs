using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class TwoDPointWithHash : TwoDPoint
    {
        private Tuple<int, int> tuple;
        public TwoDPointWithHash(int x, int y) : base(x, y)
        {
            tuple = Tuple.Create(x, y);
        }

        /* public override int GetHashCode()
         {
             return x ^ y; // ^ выполняет операцию логического исключающего XOR побитно

             // в чем тут проблема?
         }*/

        public override int GetHashCode()
        {
            return x ^ (y << 2);
        }
    }
}
