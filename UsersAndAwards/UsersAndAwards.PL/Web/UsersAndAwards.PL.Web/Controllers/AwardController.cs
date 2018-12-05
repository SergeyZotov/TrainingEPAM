using System.Linq;
using System.Web.Mvc;
using UsersAndAwards.BLL;
using UsersAndAwards.PL.Web.Models;

namespace UsersAndAwards.PL.Web.Controllers
{
    public class AwardController : Controller
    {
        Logic logic;

        public AwardController()
        {
            logic = new Logic();
        }

        public ActionResult Index()
        {
            var awards = logic.GetAllAwards()
                .Select(u => new AwardViewModel(u.Title, u.Description) { Id = u.AwardId })
                .ToList();

            return View(awards);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AwardViewModel model)
        {
            try
            {
                logic.AddAward(new Entities.Award(model.Title, model.Description));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int awardId)
        {
            var award = logic.GetAllAwards().FirstOrDefault(u => u.AwardId == awardId);

            var avm = new AwardViewModel(award.Title, award.Description) { Id = award.AwardId };

            return View(avm);
        }

        [HttpPost]
        public ActionResult Edit(AwardViewModel model)
        {
            var award = logic.GetAllAwards().FirstOrDefault(a => a.AwardId == model.Id);
            award.Title = model.Title;
            award.Description = model.Description;
            logic.EditAward(award, award.AwardId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int awardId)
        {
            var deletingAward = logic.GetAllAwards().FirstOrDefault(u => u.AwardId == awardId);
            logic.RemoveAward(deletingAward);
            return RedirectToAction("Index");
        }
    }
}