using Entities;
using System.Collections.Generic;

namespace UsersAndAwards.DAL
{
    public interface IStorage
    {
        List<User> GetAllUsers();
        List<Award> GetAllAwards();
        void AddUser(User newUser);
        void AddAward(Award newAward);
        bool RemoveUser(User user);
        bool RemoveAward(Award award);
        void EditUser(User currentUser, int row);
        void EditAward(Award currentAward, int row);
    }
}
