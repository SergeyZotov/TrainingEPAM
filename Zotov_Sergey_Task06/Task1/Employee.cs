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
            string[] dateOfBirthday, string post, string workExperience, string medicalBook, string id) : 
            base(firstName, lastName, middleName, dateOfBirthday)

        {
            if (!int.TryParse(dateOfBirthday[0], out int year) || !int.TryParse(dateOfBirthday[1], out int month) ||
                !int.TryParse(dateOfBirthday[2], out int day))
            {
                throw new ArgumentException("You can write only integer numbers!");
            }

            DateOfBirthday = new DateTime(year, month, day);
            Position = Regex.Replace(post, pattern, "");
            MedicalBook = medicalBook.ToString();
            EmployeeID = id;

            if (!double.TryParse(workExperience, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out this.workExperience))
                throw new FormatException("Work expirience must be numeric");

            WorkExperience = this.workExperience;

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
                    throw new Exception("You have to write your position");

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
                    throw new ArgumentException("You can write only \"yes/no\" ");
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

                if (id < 0)
                {
                    throw new ArgumentException("ID cannot be less than 0");
                }
            }
            get => id.ToString();
        }

    }
}
