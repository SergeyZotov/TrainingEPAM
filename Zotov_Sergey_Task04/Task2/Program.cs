using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine($"Результирующая строка:\n{GetNewString(firstLine, secondLine)}");
            Console.ReadKey();

        }

        static string GetNewString(string firstLine, string secondLine)
        {
            string resultLine = string.Empty;
            List<char> charArr2 = GetCharArray(firstLine);
            int index = 0;
            for (int i = 0; i < firstLine.Length; ++i)
            {
                resultLine = resultLine +  firstLine[i];

                foreach(var ch in charArr2)
                {
                    if (resultLine[index] == ch)
                    {
                        resultLine = resultLine + ch;
                        index++;
                        break;
                    }
                    /*if (resultLine[i] == ch)
                    {
                        resultLine = resultLine + ch;
                        break;
                    }
                    else continue;*/
                }
            }


            return resultLine;
        }

        static List<char> GetCharArray(string firstLine)
        {
            List<char> charArr = new List<char>();
            foreach(char ch in firstLine)
            {
                if (ch != ' ')
                {
                    charArr.Add(ch);
                }
            }
            return charArr;
        }
    }
}
