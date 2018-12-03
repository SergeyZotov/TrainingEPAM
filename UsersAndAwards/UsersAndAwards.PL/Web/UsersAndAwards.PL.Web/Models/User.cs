using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{

    public class User
    {
        private string _lastName;
        private string _firstName;
        private DateTime _birthday;

        public int Id { get; set; }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be empty!");
                }

                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be empty!");
                }

                _lastName = value;
            }
        }

        public DateTime Birthdate
        {
            get => _birthday;
            set
            {
                if (value > DateTime.Now || (DateTime.Now.Year - value.Year) > 150)
                {
                    throw new ArgumentException("Birthday cannot be more or less then (date now - 150 years)");
                }

                _birthday = value;
            }
        }

        public int Age => DateTime.Today.Year - Birthdate.Year - GetCorrectAgeShift();

        private int GetCorrectAgeShift()
        {

            if (Birthdate.Month > DateTime.Today.Month)
            {
                return 1;
            }
            else if (Birthdate.Month == DateTime.Today.Month)
            {
                if (Birthdate.Day <= DateTime.Today.Day)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }

        public List<Award> Awards = new List<Award>();

        public void AddAward(Award award) => Awards.Add(award);

        public void RemoveAward(Award award) => Awards.Remove(award);

    }
}