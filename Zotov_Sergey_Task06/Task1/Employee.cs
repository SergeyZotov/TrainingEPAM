using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Task1
{
    class Employee : User
    {
        private protected double workExperience;
        private protected string post;
        private protected bool medicalBook;
        private protected int id;

        public Employee(string firstName, string lastName, string middleName, 
            DateTime dateOfBirthday, string post, string workExperience, string medicalBook, string id) : 
            base(firstName, lastName, middleName, dateOfBirthday)

        {
            DateOfBirthday = dateOfBirthday;
            Position = Regex.Replace(post, pattern, "");
            MedicalBook = medicalBook.ToString();
            EmployeeID = id;

            try
            {
                WorkExperience = double.Parse(workExperience, NumberStyles.AllowDecimalPoint);

            }
            catch (FormatException)
            {
                throw new FormatException("Work expirience must be numeric");
            }
        }

        internal protected double WorkExperience
        {
            private set
            {
                if (value < 0)
                    throw new Exception("Work experience cannot be less than 0");

                workExperience = value;
            }
            get => workExperience;
        }

        internal protected string Position
        {
            private set
            {
                if (value == "")
                    throw new Exception();

                post = value;
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
                    throw new ArgumentException("ti pidor");
            }

            get => medicalBook.ToString();
        }

        internal protected double Salary => Math.Round((workExperience + 0.3) * Coefficient * 100000.5, 2);

        internal protected string EmployeeID
        {
            private set
            {
                if (!int.TryParse(value, out id))
                {
                    throw new ArgumentException("ID must be an integer number");
                }
            }
            get => id.ToString();
        }

    }
}
