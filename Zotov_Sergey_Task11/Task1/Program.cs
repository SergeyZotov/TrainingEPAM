using ClassLibrary;
using System;
using System.Runtime;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 5;

            double num1 = 4;

            int num2 = 6;

            Console.WriteLine(num2.Factorial());

            Console.WriteLine(num.Factorial());

            Console.WriteLine(num1.Pow(5));

            Console.ReadKey();
        }

    }


}
