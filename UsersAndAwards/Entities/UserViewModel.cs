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
        public string Awards { get; set; }


        public UserViewModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;
            Id = user.Id;
            Awards = string.Join(", ", user.GetAwards().Select(award => award.Title));
        }

    }
}
