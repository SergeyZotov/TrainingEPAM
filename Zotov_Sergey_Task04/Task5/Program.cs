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
            string pattern = @"<[^>]+>";
            return Regex.Replace(myString, pattern, "_");
        }
    }
}
