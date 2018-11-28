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
            }
            return _users;
        }
    }
}
