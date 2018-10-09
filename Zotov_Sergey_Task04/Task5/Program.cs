using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите HTML текст:");
            string myString = Console.ReadLine();
            Console.WriteLine($"Результат замены:\n{GetResultString(myString)}");
            Console.ReadKey();

        }

        static string GetResultString(string myString)
        {
            string pattern = @"/<([^>]+)>";
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            MatchCollection matches = regex.Matches(myString);

            StringBuilder stringBuilder = new StringBuilder(myString);
           
            foreach (MatchCollection value in matches)
            {
                stringBuilder.Replace(value.ToString(), "_");    
            }
            return stringBuilder.ToString();
        }
    }
}
