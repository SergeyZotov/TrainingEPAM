using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birthday: year month day");
            DateTime birthday = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter your first name, second name, middle name (if you have):");
            User iAm = new User(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), birthday);
            Print(iAm);
            Console.ReadKey();
        }       

        static void Print(User user)
        {
            string middleName = user.MiddleName;

            if (middleName == "")
                middleName = "Middle name is missing";

            Console.WriteLine($"Your first name:\t{user.FirstName}\n" +
                $"Your second name:\t{user.LastName}\n" +
                $"Your middle name:\t{middleName}\n" +
                $"Your birthday:\t\t{user.DateOfBirthday}\n" +
                $"Your age:\t\t{user.Age} full years");
        }
    }
}
