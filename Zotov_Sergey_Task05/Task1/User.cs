using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class User
    {
        public string firstName;
        public string lastName;
        public string middleName;
        public string dateOfBirthday;
        public double age;

        public User()
        {

        }

        public User (string firstName, string lastName, string middleName, string dateOfBirthday, double age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.dateOfBirthday = dateOfBirthday;
            this.age = age;
        }
    }
}
