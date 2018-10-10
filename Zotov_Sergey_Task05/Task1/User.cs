using System;
using System.Globalization;

namespace Task1
{
    public class User
    {
        private string FirstName
        {
            set
            {
                if (FirstName == "")
                    throw new ArgumentException("Имя не может быть пустым!");                         
            }
            get
            {
                return FirstName;
            }
        }
        private string LastName
        {
            set
            {
                if (LastName == "")
                    throw new ArgumentException("Имя не может быть пустым!");
                LastName = value;
            }
            get
            {
                return LastName;
            }
        }
        private string MiddleName
        {
            set
            {
                MiddleName = value;
            }
            get
            {
                return MiddleName;
            }
        }
        private string DateOfBirthday
        {
            set
            {
                //if (DateOfBirthday != DateTime.Now.ToString())
            }
            get
            {
                return DateOfBirthday;
            }
        }

        public User()
        {

        }

        public User (string firstName, string lastName, string middleName, string dateOfBirthday, double age)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DateOfBirthday = dateOfBirthday;
        }
    }
}
