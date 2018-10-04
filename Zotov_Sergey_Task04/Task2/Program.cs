using System;
using System.Collections.Generic;

// Does not work
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string resultLine = string.Empty;
            Console.WriteLine("Введите первую строку:");
            string firstLine = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string secondLine = Console.ReadLine();
            Console.WriteLine($"Результирующая строка:\n{GetResultString(firstLine, secondLine)}");
            Console.ReadKey();

        }

        static string GetResultString(string firstLine, string secondLine)
        {
            string resultLine = string.Empty;
            foreach (var value in firstLine)
            {
                resultLine += value;

                if (secondLine.Contains(value.ToString()))
                {
                    resultLine += value;
                }
            }
            return resultLine;
        }

        static string GetString(string firstLine)
        {
            string charArr = string.Empty;
            foreach(char ch in firstLine)
            {
                    charArr = charArr + ch.ToString();
            }
            return charArr;
        }
    }
}
