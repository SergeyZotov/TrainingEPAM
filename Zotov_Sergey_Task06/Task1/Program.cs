using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthday = GetBirthday();

            Console.WriteLine("Enter first name, last name, middle name (if you have), " +
                "profesion, work experience, medical book, id");

            Employee employee = new Employee(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(),
                birthday, Console.ReadLine(), Console.ReadLine(), (Console.ReadLine()), Console.ReadLine());

            PrintInfo(employee);
            Console.ReadKey();
    }

        static void PrintInfo(Employee employee)
        {
            string middleName;
            if (employee.MiddleName == "")
            {
                middleName = "Middle name is missing";
            }
            else
            {
                middleName = employee.MiddleName;
            }

            Console.WriteLine($"First name:\t\t{employee.FirstName}\n" +
                $"Last name:\t\t{employee.LastName}\n" +
                $"Middle name:\t\t{middleName}\n" +
                $"Day of birthday:\t{employee.DateOfBirthday.ToShortDateString()}\n" +
                $"Age:\t\t\t{employee.Age} years\n" +
                $"Profession:\t\t{employee.Position}\n" +
                $"Work expirience:\t{employee.WorkExperience} years\n" +
                $"Salary:\t\t\t{employee.Salary}\n" +
                $"Have medical book:\t{employee.MedicalBook}\n" +
                $"ID:\t\t\t{employee.EmployeeID}");
        }

        static DateTime GetBirthday()
        {

            Console.WriteLine("Enter your year of birthday:");

            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                throw new ArgumentException("Year must be an integer number!");
            }

            Console.WriteLine("Enter your month of birthday:");

            if (!int.TryParse(Console.ReadLine(), out int month))
            {
                throw new ArgumentException("Month must be an integer number!");
            }

            Console.WriteLine("Enter your day of birthday:");

            if (!int.TryParse(Console.ReadLine(), out int day))
            {
                throw new ArgumentException("Day must be an integer number!");
            }
            try
            {
                return new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException("Date must be correct!", e);
            }
        }
    }
}
