using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{
    public class AwardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsAssigned { get; set; }

        public AwardViewModel(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public static AwardViewModel GetViewModel(Award award, List<Award> userRewards)
        {
            var model = new AwardViewModel(award.Title, award.Description) { Id = award.AwardId }; 
            model.IsAssigned = userRewards.Any(r => r.AwardId == award.AwardId);

            return model;
        }
    }
}