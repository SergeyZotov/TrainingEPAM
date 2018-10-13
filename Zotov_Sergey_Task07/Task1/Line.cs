using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Line : Figure, IDrawable
    {
        public Line(string begin, string end) : base(begin, end)
        {

        }

    }
}