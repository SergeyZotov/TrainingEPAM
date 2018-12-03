using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using UsersAndAwards.DAL;

namespace UsersAndAwards.BLL
{
    public class Logic : IStorage
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

        //
        //
        //
        //
        //
        //
        //
        // for web
        public List<object> GetUsersForUI(int i = 0)
        {
            return storage.GetAllUsers().Select(u => new UserViewModel(u)).ToList<object>();
        }

        public List<object> GetAllUsers(int i = 0)
        {
            return storage.GetAllUsers().ToList<object>();
        }

        public List<object> GetAllAwards(int i = 0)
        {
            return storage.GetAllAwards().ToList<object>();
        }

        /*public void AddUser(User newUser)
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
        }*/
    }
}
