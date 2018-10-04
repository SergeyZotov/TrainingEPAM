using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string[] tempString = myString.Split(new char[] { '.', ',', '!', '?', ';',
                ':', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double avg = 0;
            int index = 0;

            foreach (var v in tempString)
            {
                avg = avg + v.Length;
                index++;
            }

            return avg / index;
        }
    }
}
