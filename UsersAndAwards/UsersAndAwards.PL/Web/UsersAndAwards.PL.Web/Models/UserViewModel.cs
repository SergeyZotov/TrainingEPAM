using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public List<Award> Awards { get; set; }

        public List<AwardViewModel> AvailableRewards { get; set; }

        public User ToUser()
        {
            var user = new User
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Birthdate = Birthdate,
                Awards = AvailableRewards
                    .Where(r => r.Checked == true)
                    .Select(r => new Award
                    {
                        AwardId = r.AwardId,
                        Title = r.Title,
                        Description = r.Description
                    }).ToList()
            };


            return user;
        }
        public static UserViewModel GetViewModel(User user, List<Award> availableRewards)
        {
            var userModel = new UserViewModel();
            userModel.Id = user.Id;
            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.Birthdate = user.Birthdate;
            userModel.Awards = user.Awards;
            var rewards = new List<AwardViewModel>();
            foreach (var reward in availableRewards)
            {
                rewards.Add(AwardViewModel.GetViewModel(reward, user.Awards));
            }

            userModel.AvailableRewards = rewards.ToList();
            return userModel;
        }
    }
}