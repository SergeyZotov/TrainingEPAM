using System;
// Testing
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            User iAm = new User();
            Initializing(iAm);
            Print(iAm);
            Console.ReadKey();
        }

        static void Initializing(User user)
        {
            if (user.firstName == user.lastName) 
            {
                Console.WriteLine("Ввведите ваше имя.");
                user.firstName = Console.ReadLine();
                Console.WriteLine("Ввведите вашу фамилию.");
                user.lastName = Console.ReadLine();
                Console.WriteLine("Ввведите ваше отчество.");
                user.middleName = Console.ReadLine();
                Console.WriteLine("Ввведите вашу дату рождения.");
                user.dateOfBirthday = Console.ReadLine();
                Console.WriteLine("Ввведите ваш возраст.");
                user.age = double.Parse(Console.ReadLine());

            }           
            else
            {
                Console.WriteLine("Вы заполнили все данные!\n");
            }
        }

        static void Print(User user)
        {
            Console.WriteLine($"Ваше имя:\t\t{user.firstName}\n" +
                $"Ваша фамилия:\t\t{user.lastName}\n" +
                $"Ваше отчество:\t\t{user.middleName}\n" +
                $"Ваша дата рождения:\t{user.dateOfBirthday}\n" +
                $"Ваш возраст:\t\t{user.age} years");
        }
    }
}
