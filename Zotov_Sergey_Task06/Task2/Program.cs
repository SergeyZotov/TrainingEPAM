using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Ring ring = new Ring(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());

            Console.WriteLine(ring);
            Console.ReadKey();
        }
    }
}
