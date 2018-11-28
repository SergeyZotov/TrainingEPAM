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

        public bool Checked { get; set; }

        public static AwardViewModel GetViewModel(Award award, List<Award> userRewards)
        {
            var model = new AwardViewModel();
            model.AwardId = award.AwardId;
            model.Title = award.Title;
            model.Description = award.Description;
            model.Checked = userRewards.Any(r => r.AwardId == award.AwardId);
            return model;
        }
    }
}