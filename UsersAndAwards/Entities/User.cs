using System;
using System.Collections.Generic;

namespace Entities
{
    public class User
    {
        
        private string lastName;
        private string firstName;
        private DateTime birthday;
        public List<Award> awards = new List<Award>();


        public User(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthday;
        }

        public int Id { get; set; }

        public List<Award> GetAwards() => awards;

        public void AddAward(Award award) => awards.Add(award);

        public void RemoveAward(Award award) => awards.Remove(award);

        public string FirstName
        {
            get => firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be empty!");
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be empty!");
                }

                lastName = value;
            }
        }

        public DateTime Birthdate
        {
            get => birthday;
            set
            {
                if (value > DateTime.Now || (DateTime.Now.Year - value.Year) > 150)
                {
                    throw new ArgumentException("Birthday cannot be more or less then (date now - 150 years)");
                }

                birthday = value;
            }
        }

        public int Age =>  DateTime.Today.Year - Birthdate.Year - GetCorrectAgeShift();

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
                    return 1;
                }
            }

            return 0;
        }


    }
}
