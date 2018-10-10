using System;
using System.Text.RegularExpressions;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите вашу строку");
            string myString = Console.ReadLine();
            Console.WriteLine($"The time occurs in text {GetMatchesCount(myString).Count} time(-s)");
            Console.ReadKey();
        }

        static MatchCollection GetMatchesCount(string myString)
        {
            string pattern = @"\b((([0-1]?[0-9])|([0-2][0-3])):[0-5][0-9])\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.Matches(myString);
        }
    }
}
