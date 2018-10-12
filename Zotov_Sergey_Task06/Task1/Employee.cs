using System;
using System.Text.RegularExpressions;
using System.Globalization;
using Task1;

namespace Task1
{
    class Employee : User
    {
        //private string pattern1 = @"(\s+[\W*])|(\s+((N?n?O?o?)|(Y?y?E?e?S?s?)))|([0-9]+)";
        private protected double workExperience;
        private protected string post;
        private protected string medicalBook;
        private string noPattern = @"^([Nn])[Oo]";
        private string yesPattern = @"^([Yy])[Ee][Ss]";
        private string pattern = @"(\b[Nn]?[Oo]?\b)|(\b[Yy]?[Ee]?[Ss]?\b)";

        public Employee(string firstName, string lastName, string middleName, 
            DateTime dateOfBirthday, string post, string workExperience, string medicalBook) : 
            base(firstName, lastName, middleName, dateOfBirthday)

        {
            Position = Regex.Replace(post, base.pattern, "");

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
                if (Regex.IsMatch(value.ToString(), noPattern))
                {
                    MedicalBook = "false";
                }
                else 
                if (Regex.IsMatch(value.ToString(), yesPattern))
                {
                    MedicalBook = "true";
                }
                else
                    throw new ArgumentException("You can write yes/no only");
            }

            get => medicalBook;
        }

        internal protected double Salary => Math.Round((workExperience + 0.3) * Coefficient * 100000.5, 2);
    }
}
