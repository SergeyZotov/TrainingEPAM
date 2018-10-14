using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Line : Figure
    {
        public Line(string begin, string end) : base(begin, end)
        {

        }

        public override string Draw()
        {
            return $"This figure is a line. This line begins at point {X} and ends at point {Y}";
        }

    }
}