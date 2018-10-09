using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите вашу строку");
            string myString = Console.ReadLine();
            Console.WriteLine($"The time occurs in text {TimeSearch(myString).Count} time(-s)");
            Console.ReadKey();
        }

        static MatchCollection TimeSearch(string myString)
        {
            string pattern = @"([0-2]?[0-3]?:[0-5]?[0-9]?)|([0-9]?:[0-5]?[0-9]?)";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.Matches(myString);
        }

        static void Print(MatchCollection matches)
        {
            Console.WriteLine($"The time occurs in text {matches.Count} time(-s)");
        }
    }
}
