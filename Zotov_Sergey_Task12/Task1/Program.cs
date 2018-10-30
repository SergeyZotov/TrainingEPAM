using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\USER\Desktop\EPAM\disposable_task_file.txt";
            string[] stringArrayOfNumbers;
            int[] numbers;
            using (StreamReader reader = new StreamReader(path))
            {
                stringArrayOfNumbers = reader.ReadToEnd().Split('\n');
                numbers = new int[stringArrayOfNumbers.Length];
                SquareOfNumbers(stringArrayOfNumbers, numbers);
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var value in numbers)
                {
                    string num = value.ToString() + Environment.NewLine;
                    writer.Write(num);
                }
            }
        }

        static void SquareOfNumbers(string[] numbers, int[] numbers1)
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                int.TryParse(numbers[i], out int num);
                numbers1[i] = num * num;
            }
        }
    }
}
