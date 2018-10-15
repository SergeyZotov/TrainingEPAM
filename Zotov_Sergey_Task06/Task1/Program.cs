using System;
using System.Diagnostics;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter year, month and day of your birthday in one line:");

            string[] birthday = Console.ReadLine().Split(new char[] { '.', ' ', '\n' }, 3);

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
                $"Age:\t\t\t{employee.Age} full years\n" +
                $"Profession:\t\t{employee.Position}\n" +
                $"Work expirience:\t{employee.WorkExperience} years\n" +
                $"Salary:\t\t\t{employee.Salary}\n" +
                $"Have medical book:\t{employee.MedicalBook}\n" +
                $"ID:\t\t\t{employee.EmployeeID}");
        }
    }
}
