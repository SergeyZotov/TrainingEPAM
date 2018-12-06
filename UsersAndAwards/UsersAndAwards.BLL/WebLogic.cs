using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAndAwards.DAL;

namespace UsersAndAwards.BLL
{
    public class WebLogic : IStorage
    {
        IStorage storage;

        public Logic()
        {
            if (DBStorage.providerName.Contains("System.Data.SqlClient"))
            {
                storage = new DBStorage();
            }
            else
            {
                storage = new InMemoryStorage();
            }
        }

        public List<UserViewModel> GetUsersForUI()
        {
            return storage.GetAllUsers().Select(u => new UserViewModel(u)).ToList();
        }

        public List<User> GetAllUsers()
        {
            return storage.GetAllUsers().ToList();
        }

        public List<Award> GetAllAwards()
        {
            return storage.GetAllAwards();
        }

        public void AddUser(User newUser)
        {
            storage.AddUser(newUser);
        }

        public void AddAward(Award award)
        {
            storage.AddAward(award);
        }

        public void EditAward(Award award, int indexOfSelectedAward)
        {
            storage.EditAward(award, indexOfSelectedAward);
        }

        public bool RemoveAward(Award award)
        {
            return storage.RemoveAward(award);
        }

        public void EditUser(User newUser, int indexOfSelectedUser)
        {
            storage.EditUser(newUser, indexOfSelectedUser);
        }

        public bool RemoveUser(User user)
        {
            return storage.RemoveUser(user);
        }
    }
}
