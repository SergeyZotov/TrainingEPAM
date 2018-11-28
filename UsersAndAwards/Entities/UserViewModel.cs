using System;
using System.Linq;

namespace Entities
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Awards { get; set; }


        public UserViewModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;
            Age = user.Age;
            Id = user.Id;
            Awards = string.Join(", ", user.Awards.Select(award => award.Title));
        }
    }
}
