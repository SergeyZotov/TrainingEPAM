using System;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultString = string.Empty;
            Console.WriteLine("Введите первую строку:");
            string firstString = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string secondString = Console.ReadLine();
            Console.WriteLine("Результирующая строка:");
            resultString = GetResultString(firstString, secondString);
            Console.WriteLine(resultString);
            Console.ReadKey();

        }

        static string GetResultString(string firstString, string secondString)
        {
            foreach (var value in GetChangedString(secondString))
            {
                firstString = firstString.Replace($"{value}", $"{value}{value}");
            }

            return firstString;
        }

        static string GetChangedString(string str)
        {

            StringBuilder shortierString = new StringBuilder();

            foreach (char c in str)
            {
                if (shortierString.ToString().IndexOf(c) == -1)
                {
                    shortierString.Append(c);
                }
            }

            return shortierString.ToString();

        }
    }
}
