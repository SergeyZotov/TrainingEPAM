using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку");
            MyString ms1 = new MyString(Console.ReadLine());
            Console.WriteLine("Введите вторую строку");
            MyString ms2 = new MyString(Console.ReadLine());
            Console.WriteLine($"My strings are equal : {ms1 == ms2}");
            Console.WriteLine($"My strings are not equal : {ms1 != ms2}");
            Console.WriteLine($"My first string plus my second string equals to \"{ms1 + ms2}\"");
            Console.WriteLine($"My first string minus my second string equals to \"{ms1 - ms2}\"");
            Console.ReadKey();
        }
    }
}
