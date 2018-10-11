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
            //Console.WriteLine("Введите вашу строку");
            MyString ms1 = new MyString(" hello");
            MyString ms2 = new MyString("hello");
            Console.WriteLine(ms2 + ms1);

            /*for (int i = 0; i < ms2.Length; ++i)
            {
                Console.Write(ms2[i].ToString());
            }*/

            Console.ReadKey();
        }
    }
}
