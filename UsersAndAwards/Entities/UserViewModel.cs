using System;
using System.Linq;

namespace Entities
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Awards { get; set; }
        public int id;

        public UserViewModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthdate = user.Birthdate;
            id = user.Id;
            Awards = string.Join(", ", user.GetAwards().Select(award => award.Title));
        }

    }
}
