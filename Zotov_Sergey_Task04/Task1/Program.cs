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
            string pattern = @"\s+";
            Regex regex = new Regex(pattern, RegexOptions.Singleline);
            var temp = regex.Split(myString);
            double average = 0;
            int index = 0;

            foreach (var value in temp)
            {
                if (value == "")
                    continue;
                average = average + value.Length;
                index++;
            }

            return average / index;
        }
    }
}
