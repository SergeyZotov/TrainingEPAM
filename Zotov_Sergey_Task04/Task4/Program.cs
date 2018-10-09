using System;
using System.Text;
using System.Diagnostics;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;
            var watcher1 = Stopwatch.StartNew();

            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            watcher1.Stop();

            Console.WriteLine($"Вот так работает сложение в string:\t\t{watcher1 .Elapsed}");

            var watcher = Stopwatch.StartNew();

            watcher.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            watcher.Stop();

            Console.WriteLine($"Вот так работает сложение в StringBuilder:\t{watcher.Elapsed}");
            Console.ReadKey();
        }
    }
}
