using System.Linq;
using System.Web.Mvc;
using UsersAndAwards.BLL;
using UsersAndAwards.PL.Web.Models;

namespace UsersAndAwards.PL.Web.Controllers
{
    public class UserController : Controller
    {
        Logic logic;

        public UserController()
        {
            logic = new Logic();
        }

        public ActionResult Index()
        {
            var users = logic.GetAllUsers()
                .Select(u => new UserViewModel(u.FirstName, u.LastName, u.Birthdate, u.Awards) { Id = u.Id })
                .ToList();

            return View(users);

        }

        public ActionResult Edit(int userId)
        {
            var user = logic.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            var awards = logic.GetAllAwards().Select(a => new AwardViewModel(a.Title, a.Description) { Id = a.AwardId }).ToList();
            var userAndAwardsModel = new UserAndAwardsModel
            {
                User = new UserViewModel(user.FirstName, user.LastName, user.Birthdate, user.Awards) { Id = user.Id, Age = user.Age, Awards = user.Awards },
                AllAvailableAwards = awards

            };

            foreach (var aw in user.Awards)
            {
                foreach (var award in userAndAwardsModel.AllAvailableAwards)
                {
                    if (aw.AwardId == award.Id)
                    {
                        award.IsAssigned = true;
                    }
                }
            }
            return View(userAndAwardsModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, UserAndAwardsModel userModel)
        {
            if (userModel != null)
            {
                userModel.User.Id = id;

                var currentUser = logic.GetAllUsers().FirstOrDefault(u => u.Id == id);

                var awards = logic.GetAllAwards();
                int i = 0;
                foreach (var award in awards)
                {
                    if (award.AwardId == userModel.AllAvailableAwards[i].Id)
                    {
                        userModel.AllAvailableAwards[i].Title = award.Title;
                        userModel.AllAvailableAwards[i].Description = award.Description;
                        i++;
                    }
                }

                if (currentUser != null)
                {
                    var user = userModel.ToUser(userModel.User, userModel.AllAvailableAwards);
                    currentUser.FirstName = user.FirstName;
                    currentUser.LastName = user.LastName;
                    currentUser.Birthdate = user.Birthdate;
                    currentUser.Awards = user.Awards;
                    logic.EditUser(currentUser, currentUser.Id);
                }
            }

            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            var awards = logic.GetAllAwards().Select(a => new AwardViewModel(a.Title, a.Description) { Id = a.AwardId }).ToList();
            var userAndAwardsModel = new UserAndAwardsModel
            {
                AllAvailableAwards = awards
            };

            return View(userAndAwardsModel);
        }

        [HttpPost]
        public ActionResult Add(UserAndAwardsModel userModel)
        {
            var awards = logic.GetAllAwards();
            int i = 0;

            foreach (var award in userModel.AllAvailableAwards)
            {
                award.Id = awards[i].AwardId;
                i++;
            }
            i = 0;
            foreach (var award in awards)
            {
                if (award.AwardId == userModel.AllAvailableAwards[i].Id)
                {
                    userModel.AllAvailableAwards[i].Title = award.Title;
                    userModel.AllAvailableAwards[i].Description = award.Description;
                    i++;
                }
            }

            logic.AddUser(userModel.ToUser(userModel.User, userModel.AllAvailableAwards));

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int userId)
        {
            var deletingUser = logic.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            logic.RemoveUser(deletingUser);

            return RedirectToAction("Index");
        }
    }
}