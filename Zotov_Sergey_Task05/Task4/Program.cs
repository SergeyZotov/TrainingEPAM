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
            MyString ms1 = new MyString(" ");
            //Console.WriteLine("Введите вторую строку");
            MyString ms2 = new MyString("");
            Console.WriteLine(ms1 == ms2);

            /*for (int i = 0; i < ms2.Length; ++i)
            {
                Console.Write(ms2[i].ToString());
            }*/

            Console.ReadKey();
        }
    }
}
