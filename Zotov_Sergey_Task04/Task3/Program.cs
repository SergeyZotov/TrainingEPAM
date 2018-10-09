using System;
using System.Globalization;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintTable();
            Console.ReadKey();
        }

        static void PrintTable()
        {
            string table = $"Культура\t\tФормат даты\t\tЗапись вещественного числа\t\tВремя\n";
            Console.WriteLine(table);
            Console.WriteLine($"{CultureInfo.CurrentCulture}\t\t\t{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}" +
                $"\t\t5{CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator}56" +
                $"\t\t\t\t\t{CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern}");

            Console.WriteLine($"Invariant\t\t{CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern}" +
                $"\t\t5{CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator}56" +
                $"\t\t\t\t\t{CultureInfo.InvariantCulture.DateTimeFormat.LongTimePattern}");

            Console.WriteLine($"{CultureInfo.GetCultureInfo("en-US")}\t\t\t{CultureInfo.GetCultureInfo("en-US").DateTimeFormat.ShortDatePattern}" +
                $"\t\t5{CultureInfo.GetCultureInfo("en-US").NumberFormat.CurrencyDecimalSeparator}56" +
                $"\t\t\t\t\t{CultureInfo.GetCultureInfo("en-US").DateTimeFormat.LongTimePattern}");

            Console.WriteLine($"{CultureInfo.GetCultureInfo("sw-SW")}\t\t\t{CultureInfo.GetCultureInfo("sw-SW").DateTimeFormat.ShortDatePattern}" +
                $"\t\t5{CultureInfo.GetCultureInfo("sw-SW").NumberFormat.CurrencyDecimalSeparator}56" +
                $"\t\t\t\t\t{CultureInfo.GetCultureInfo("sw-SW").DateTimeFormat.LongTimePattern}");
        }
    }
}
