using Entities;
using System.Collections.Generic;

namespace UsersAndAwards.DAL
{
    public class InMemoryStorage : IStorage
    {
        private List<User> _users = new List<User>();
        private List<Award> _awards = new List<Award>();
        private int userId = 0;
        private int awardId = 0;

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public List<Award> GetAllAwards()
        {
            return _awards;
        }

        public void AddUser(User user)
        {
            user.Id = ++userId;
            _users.Add(user);
        }

        public void AddAward(Award award)
        {
            award.Id = ++awardId;
            _awards.Add(award);
        }

        public bool RemoveUser(User user)
        {
            foreach (var man in _users)
            {
                if (man.FirstName == user.FirstName && man.LastName == user.LastName &&
                    man.Birthdate == user.Birthdate)
                {
                    _users.Remove(man);
                    return true;
                }
            }
            return false;        
        }

        public void EditUser(User user, int row)
        {
            _users[row] = user;
        }

        public void EditAward(Award award, int row)
        {
            _awards[row] = award;
        }

        public bool RemoveAward(Award award)
        {
            foreach (var innerAward in _awards)
            {
                if (innerAward.Title == award.Title)
                {
                    foreach (var user in _users)
                    {
                        user.RemoveAward(award);
                    }
                    _awards.Remove(award);
                    return true;
                }
            }
            return false;
        }
    }
}
