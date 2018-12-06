using Entities;
using System.Collections.Generic;
using System.Linq;

namespace UsersAndAwards.PL.Web.Models
{
    public class UserAndAwardsModel
    {
        public UserViewModel User { get; set; }
        public List<AwardViewModel> AllAvailableAwards { get; set; }

        public User ToUser(UserViewModel user, List<AwardViewModel> aw)
        {
            return new User(user.FirstName, user.LastName, user.Birthdate)
            {
                Id = user.Id,
                Awards = aw
                .Where(a => a.IsAssigned == true)
                .Select(a => new Award(a.Title, a.Description)
                {
                    AwardId = a.Id
                }).ToList()
            };
        }
    }
}