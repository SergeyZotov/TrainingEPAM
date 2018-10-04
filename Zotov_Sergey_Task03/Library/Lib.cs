using System;

namespace Library
{
    public class Init
    {
        Random rand = new Random();

        public void Initializing(int[] Arr)
        {
            for (int i = 0; i < 10; ++i)
                Arr[i] = rand.Next(-100, 100);
        }

        public void Initializing(int[,] Arr)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Arr[i, j] = rand.Next(-100, 100);
                }
            }
        }

        public void Initializing(int[, ,] Arr)
        {

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    for (int k = 0; k < 5; ++k)
                    {
                        Arr[i, j, k] = rand.Next(-100, 100);
                    }
                }
            }
        }
    }

    public class Printer
    {
        public void Print(int[] Arr)
        {
            foreach (int value in Arr)
                Console.Write(value + "  ");

            Console.WriteLine('\n');
        }

        public void Print(int[,] Arr)
        {
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write($"{Arr[i, j]} \t");
                }

                Console.WriteLine();
            }

            Console.WriteLine('\n');
        }

        public void Print(int[,,] Arr)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    for (int k = 0; k < 5; ++k)
                    {
                        Console.Write($"{Arr[i, j, k]} \t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine('\n');

            }
        }
    }
}
