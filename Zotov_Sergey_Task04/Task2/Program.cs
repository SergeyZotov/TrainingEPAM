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
            resultString = GetResultString(firstString, secondString);
            Console.WriteLine(resultString);
            Console.ReadKey();

        }

        static string GetResultString(string firstString, string secondString)
        {
            // Можно через string.replace, regex
            StringBuilder resultString = new StringBuilder();
           
            foreach (var value in firstString)
            {
                resultString.Append(value.ToString());

                if (secondString.Contains(value.ToString()))
                {
                    resultString.Append(value.ToString());
                }
            }

            return resultString.ToString();
        }
    }
}
