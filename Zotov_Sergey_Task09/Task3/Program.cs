using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string englishText = "hello there. i am sergey 21, hey TheRe there THeRE, , ,, , , , HEY, heY, Sergey, I, 12";
            Console.WriteLine($"Your text is:\n{englishText}\n");
            string[] words = GetArrayOfWords(englishText);
            Dictionary<string, int> dictionary = GetDictionary(words);
            dictionary = GetDictionaryWithFoundWords(dictionary, words);
            Print(dictionary);
            Console.ReadKey();
        }

        static string[] GetArrayOfWords(string text) => Regex.Split(text, @"\W+");

        static void Print(Dictionary<string, int> dictionary)
        {
            foreach(var value in dictionary)
            {
                Console.WriteLine($"Word \"{value.Key}\" occurs {value.Value} time(-s)");
            }
        }

        static Dictionary<string, int> GetDictionary(string[] words)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string temp = default;

            foreach(var word in words)
            {
                temp = word.ToLower();

                if (dictionary.ContainsKey(temp))
                    continue;

                dictionary.Add(word, 0);
            }

            return dictionary;
        }

        static Dictionary<string, int> GetDictionaryWithFoundWords(Dictionary<string, int> dictionary, string[] words)
        {
            Dictionary<string, int> tempDictionary = new Dictionary<string, int>(dictionary);

            foreach (var key in tempDictionary.Keys)
            {
                foreach (string word in words)
                {
                    if (word.ToLower() == key)
                    {
                        dictionary[key] = dictionary[key] + 1;
                    }
                }
            }

            return dictionary;
        }
    }
}
