using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class Library
    {
        public static double Factorial(this int number)
        {
            double fact = 1;
            if (number == 0 || number == 1)
                return 1;
            else
            {
                for (int i = 2; i < number + 1; ++i)
                    fact *= i;
            }

            return fact;
        }

        public static double Pow(this double number, double degree)
        {
            if (degree == 0)
                return 1;
            else
            {
                number = Math.Exp(degree * Math.Log(number));
            }

            return number;
        }

    }
    
}
