using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Task1
{
    public class User
    {
        private static string pattern = @"(\s+[\W*])|(\s+\w*[a-zA-Z])|([0-9])";
        private string firstName = "";
        private string lastName = "";
        private string middleName = "";
        private string dateOfBirthday = "";

        public User(string firstName, string lastName, string middleName, string dateOfBirthday)
        {
            FirstName = Regex.Replace(firstName, pattern, "");
            LastName = Regex.Replace(lastName, pattern, "");
            MiddleName = Regex.Replace(middleName, pattern, "");
            DateOfBirthday = dateOfBirthday;
        }

        internal string FirstName
        {
            private set
            {
                if (value == "")
                    throw new ArgumentException("First name cannot be empty!");

                firstName = value;
            }
            get
            {
                return firstName;
            }
        }

        internal string LastName
        {
            private set
            {
                if (value == "")
                    throw new ArgumentException("Last name cannot be empty!");

                lastName = value;
            }
            get
            {
                return lastName;
            }
        }

        internal string MiddleName
        {
            private set
            {
                    middleName = value;
            }
            get
            {
                return middleName;
            }
        }

        internal string DateOfBirthday
        {
            private set
            {
                if (DateTime.Parse(value) > DateTime.Now || DateTime.Parse(value) < DateTime.Parse("01.01.1900"))
                    throw new ArgumentException("Your date is more than current date");

                dateOfBirthday = value;
            }
            get
            {
                return dateOfBirthday;
            }
        }
    }
}
