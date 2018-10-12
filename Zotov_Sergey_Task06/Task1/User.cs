using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Task1
{
    public class User
    {
        private protected string pattern = @"(\s+[\W*])|(\s+\w*)|([0-9]+)";
        private protected string firstName = "";
        private protected string lastName = "";
        private protected string middleName = "";
        private protected DateTime dateOfBirthday;
        private protected int age;                

        public User(string firstName, string lastName, string middleName, DateTime dateOfBirthday)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DateOfBirthday = dateOfBirthday;
        }

        internal protected string FirstName
        {
            private protected set
            {
                if (string.IsNullOrWhiteSpace(Regex.Replace(value, pattern, "")))
                    throw new ArgumentException("First name cannot be empty!");

                firstName = value;
            }
            get => firstName;
        }

        internal protected string LastName
        {
            private protected set
            {
                if (string.IsNullOrWhiteSpace(Regex.Replace(value, pattern, "")))
                    throw new ArgumentException("Last name cannot be empty!");

                lastName = value;
            }
            get => lastName;
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

        internal protected DateTime DateOfBirthday
        {
            private protected set
            {
                if (DateTime.Parse(value.ToString()) > DateTime.Now || DateTime.Parse(value.ToString()) < DateTime.Parse("01.01.1900"))
                    throw new ArgumentException("Your date is more than current date");

                dateOfBirthday = value;
            }
            get => dateOfBirthday;
        }

        internal protected int Age
        {
            get
            {
                age = DateTime.Now.Year - DateOfBirthday.Year;

                if ((DateOfBirthday.Month < DateTime.Now.Month && DateOfBirthday.Day < DateTime.Now.Day) ||
                    (DateOfBirthday.Day < DateTime.Now.Day && DateOfBirthday.Month == DateTime.Now.Month))
                {
                    return --age;
                }
                else
                    return age;                                                
            }
        }

    }
}
