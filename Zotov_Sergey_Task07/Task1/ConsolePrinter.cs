using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class ConsolePrinter : IPrinter
    {
        public void Print(IDrawable figure)
        {
            Console.WriteLine(figure.Draw());
        }
    }
}
