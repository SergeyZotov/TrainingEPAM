using System;
using System.Diagnostics;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first name, last name, middle name (if you have), " +
                "year and month and day of birthday, profesion,\nwork experience, medical book, id");

            try
            {
                Employee employee = new Employee(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(),
                    new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())),
                    Console.ReadLine(), double.Parse(Console.ReadLine()), (Console.ReadLine()), int.Parse(Console.ReadLine()));

                PrintInfo(employee);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("You enter wrong data");
            }
            catch(FormatException)
            {
                Console.WriteLine("ID must be integer");
            }

            Console.ReadKey();
    }

        static void PrintInfo(Employee employee)
        {
            string middleName;

            if (string.IsNullOrEmpty(employee.MiddleName))
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
