using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{
    public class AwardViewModel
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsAssigned { get; set; }

        public static Award GetViewModel(Award award, List<Award> userRewards)
        {
            var model = new Award();
            model.Id = award.Id;
            model.Title = award.Title;
            model.Description = award.Description;
            model.IsAssigned = userRewards.Any(r => r.Id == award.Id);
            return model;
        }
    }
}