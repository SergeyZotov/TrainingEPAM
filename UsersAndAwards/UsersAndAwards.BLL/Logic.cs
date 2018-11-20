using Entities;
using System.Collections.Generic;
using System.Linq;
using UsersAndAwards.DAL;

namespace UsersAndAwards.BLL
{
    public class Logic
    {
        private List<UserViewModel> _users;

        public List<UserViewModel> GetUsersForUI(List<User> users, IStorage memory)
        {
            _users = new List<UserViewModel>();

            for (int i = 0; i < users.Count; i++)
            {
                _users.Add(new UserViewModel(users[i]));
                _users[i].Awards = GetStringAwards(users[i], memory);
            }
            return _users;
        }

        private string GetStringAwards(User user, IStorage memory)
        {
            var stringAwardsOfUser = memory.GetAllAwards();
            string awards = string.Empty;

            foreach (var award in stringAwardsOfUser)
            {
                if (user.GetAwards().Contains(award))
                {
                    awards = string.Join(", ", user.GetAwards().Select(_award => _award.Title));
                }
            }
            return awards;
        }
    }
}
