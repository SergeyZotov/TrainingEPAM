using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace Task1
{
    class Employee : User, IEquatable<Employee>
    {
        private protected double workExperience;
        private protected string post;
        private protected bool medicalBook;
        private protected int id;

        public Employee(string firstName, string lastName, string middleName, 
            DateTime dateOfBirthday, string post, double workExperience, string medicalBook, int id) : 
            base(firstName, lastName, middleName, dateOfBirthday)

        {
            Position = Regex.Replace(post, pattern, "");
            MedicalBook = medicalBook.ToString();
            EmployeeID = id;
            WorkExperience = workExperience;
        }

        internal protected double WorkExperience
        {
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Work experience cannot be less than 0");

                workExperience = value;
            }
            get => workExperience;
        }

        internal protected string Position
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("You have to write your position");

                post = Regex.Replace(value, pattern, "");
            }
            get => post;
        }

        private double Coefficient
        {
            get
            {
                if (workExperience < 3)
                    return 0.12;
                else if (workExperience < 5 && workExperience >= 3)
                    return 0.3;
                else
                    return 0.5;
            }
        }

        internal protected string MedicalBook
        {
            private set
            {
                if (value.ToString().Equals("yes"))
                    medicalBook = true;
                else if (value.ToString().Equals("no"))
                    medicalBook = false;
                else
                    throw new ArgumentException("You can write only \"yes/no\" ");
            }

            get => medicalBook.ToString();
        }

        internal protected double Salary => Math.Round((workExperience + 0.3) * Coefficient * 100000.5, 2);

        internal protected int EmployeeID
        {
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID cannot be less than 0");
                }

                id = value;
            }
            get => id;
        }

        public bool Equals(Employee other)
        {
            /*if (GetHashCode() == other.GetHashCode())
                return true;
            else return false;*/
            if (FirstName == other.FirstName && LastName == other.LastName &&
                MiddleName == other.MiddleName && DateOfBirthday == other.DateOfBirthday &&
                EmployeeID == other.EmployeeID)
                return true;
            else return false;
        }
    } 
}
