using System;
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

        public User(string firstName, string lastName, string middleName, string[] dateOfBirthday)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            int year;
            int month;
            int day;

            try
            {
                year = int.Parse(dateOfBirthday[0]);
                month = int.Parse(dateOfBirthday[1]);
                day = int.Parse(dateOfBirthday[2]);
            }
            catch(FormatException)
            {
                throw new ArgumentException("You can write only integer numbers!");
            }
            catch
            {
                throw new ArgumentOutOfRangeException("You did not write all data!");
            }

            DateOfBirthday = new DateTime(year, month, day);
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

                try
                {
                    value =  new DateTime(value.Year, value.Month, value.Day);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException("Date must be correct!", e);
                }

                dateOfBirthday = value;
            }
            get => dateOfBirthday;
        }

        internal protected int Age
        {
            get
            {
                age = DateTime.Now.Year - 1;

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
