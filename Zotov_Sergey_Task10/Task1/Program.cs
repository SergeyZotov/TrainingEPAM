using System;

namespace Task1
{
    internal class Program 
    {
        delegate bool Compare(string string1, string string2);

        static void Main(string[] args)
        {
            string s1 = "HEllo worl";
            string s2 = "helLo world";
            string s3 = "aello wor";
            string s4 = "AEllo world";
            string s5 = "Hello wrld";
            string s6 = "hello w";
            string s7 = "Aallo world";
            string s8 = "hello passs";
            string s9 = "passs world";
            string s10 = "Cd";
            string s11 = "HELLO WORDL";

            Compare comparer = IsFirstStringLonger;
            string[] strings = new string[] { s2, s3, s1, s4 , s5, s6, s7, s8, s9, s10, s11};
            Console.WriteLine("Массив строк до сортировки");
            Print(strings);
            Console.WriteLine();
            StringSorting(strings, comparer);
            Console.WriteLine("Массив строк после сортировки");
            Print(strings);
            Console.ReadKey();
        }

        static bool Smth(string s1, string s2)
        {
            if (s1.Length > s2.Length)
                return false;
            else return true;
        }

        static void Print(string[] strings)
        {
            foreach (var value in strings)
            {
                Console.WriteLine(value);
            }
        }

        static void StringSorting(string[] strings, Compare comparer)
        {
            for(int i = 0; i < strings.Length - 1; ++i)
            {
                for (int j = i + 1; j < strings.Length; j++)
                {
                    if (comparer(strings[i].ToLower(), strings[j].ToLower()))
                    {
                        var temp = strings[i];
                        strings[i] = strings[j];
                        strings[j] = temp;
                    }
                }
            }
        }

        static bool IsFirstStringLonger(string firstString, string secondString) => firstString.Length > secondString.Length == true ?
            true : firstString.Length == secondString.Length ? (string.Compare(firstString, secondString, true) == 1 ? true : false) : false;
        /*{
            int str1L = firstString.Length;
            int str2L = secondString.Length;

            if (str1L > str2L)
            {
                return true;
            }
            else if (str1L == str2L)
            {
                if (string.Compare(firstString, secondString, true) == 1)
                {
                    return true;
                }
            }
            return false;
        }*/
    }
}
