using System;
using System.Text;

// Does not work
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
            Console.WriteLine(GetResultString(firstString, secondString));
            Console.ReadKey();

        }

        static string GetResultString(string firstString, string secondString)
        {
            string resultString = string.Empty;

            foreach (var value in firstString)
            {
                resultString = resultString + value.ToString();

                if (secondString.Contains(value.ToString()))
                {
                    resultString = resultString + value.ToString();
                }
            }

            return resultString;
        }
    }
}
