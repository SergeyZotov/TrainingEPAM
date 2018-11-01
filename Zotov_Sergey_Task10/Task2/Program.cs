using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Office office = new Office();

            Person john = new Person("Джон");
            office.Add(john);
            Person bill = new Person("Билл");
            office.Add(bill);
            Person hugo = new Person("Хьюго");
            office.Add(hugo);

            office.Remove(john);

            office.Remove(bill);

            office.Remove(hugo);

            Console.ReadKey();
        }
    }
}
