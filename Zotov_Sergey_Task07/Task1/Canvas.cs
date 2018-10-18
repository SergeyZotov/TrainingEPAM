using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Canvas
    {
        private IPrinter printer;

        public List<IDrawable> arrayOfFigures = new List<IDrawable>();

        public Canvas(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Draw()
        {
            foreach(var value in arrayOfFigures)
            {
                printer.Print(value);
            }
        }
    }
}
