using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyEventArgs : EventArgs
    {
        public DateTime Time { get; }

        public MyEventArgs(DateTime time)
        {
            Time = time;
        }
    }
}
