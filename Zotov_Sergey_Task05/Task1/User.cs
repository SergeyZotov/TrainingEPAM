using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Task1
{//[a-zA-Z]
    public class User
    {
        private protected string pattern = @"(\s+[\W*])|(\s+\w*)|([0-9]+)";
        private protected string firstName = "";
        private protected string lastName = "";
        private protected string middleName = "";
        private protected string dateOfBirthday = "";

        public User(string firstName, string lastName, string middleName, string dateOfBirthday)
        {
            FirstName = Regex.Replace(firstName, pattern, "");
            LastName = Regex.Replace(lastName, pattern, "");
            MiddleName = Regex.Replace(middleName, pattern, "");
            DateOfBirthday = dateOfBirthday;
        }

        internal protected string FirstName
        {
            private protected set
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

        internal protected string LastName
        {
            private protected set
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

        internal protected string MiddleName
        {
            private protected set
            {
                    middleName = value;
            }
            get
            {
                return middleName;
            }
        }

        internal protected string DateOfBirthday
        {
            private protected set
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
