using System;

namespace Lib
{
    public class Library
    {
        public void Initializing(int[] Arr)
        {
            Random rand = new Random();

            for (int i = 0; i < 10; ++i)
                Arr[i] = rand.Next(-100, 100);
        }

        static void Initializing(int[,] Arr)
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
    }
}


