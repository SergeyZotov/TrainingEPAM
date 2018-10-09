using System;
using System.Text.RegularExpressions;
// Does not work
// HTML теги
namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите HTML текст:");
            string myString = Console.ReadLine();
            Console.WriteLine($"Результат замены:\n{Result(myString)}");
            Console.ReadKey();

        }

        static string Result(string myString)
        {
            string pattern = @"/<[\W+]>";
            Regex regex = new Regex(pattern);

            myString = regex.Replace(myString, pattern);
            return myString;
        }
    }
}
