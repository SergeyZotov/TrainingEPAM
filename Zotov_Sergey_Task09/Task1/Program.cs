using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of people:");

            int N = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();

            Console.WriteLine("Односвязный список:");
            Initialization(list, N);
            Print(list);
            RemoveEachSecondItem(list);

            Console.WriteLine("Двусвязный список:");
            Initialization(linkedList, N);
            Print(linkedList);
            RemoveEachSecondItem(linkedList);

            Console.ReadKey();
        }

        static void RemoveEachSecondItem(ICollection<int> list)
        {
            int count = 1;
            int n = 0;

            while (list.Count > 1)
            {
                List<int> tempList = new List<int>(list);

                foreach (var value in tempList)
                {
                    if (count % 2 == 0)
                    {
                        list.Remove(value);
                    }

                    count++;
                }
                n++;
                Console.WriteLine($"Текущая коллекция после {n} прохода:");
                Print(list);
                count = 1;
            }
        }

        static void Print(ICollection<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void Initialization(ICollection<int> list, int count)
        {
            for (int i = 1; i < count + 1; ++i)
            {
                list.Add(i);
            }
        }
    }
}
