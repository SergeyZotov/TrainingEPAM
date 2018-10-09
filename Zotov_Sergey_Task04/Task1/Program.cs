using System;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку:");
            string myString = Console.ReadLine();
            Console.WriteLine($"Средняя длина слова в введенной строке равна {Math.Round(GetAverageLengthOfWords(myString), 2)}");
            Console.ReadKey();
        }

        static double GetAverageLengthOfWords(string myString)
        {
            string pattern = @"\s{0}\b(\w+)\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
            double average = 0;
            int index = 0;

            MatchCollection matches = regex.Matches(myString);

            foreach(var match in matches)
            {
                average += match.ToString().Length;
                index++;
            }

            return average / index;
        }
    }
}
