
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var uvm = new UserAndAwardsModel
            {
                User = new UserViewModel(user.FirstName, user.LastName, user.Birthdate, user.Awards) { Id = user.Id, Age = user.Age, Awards = user.Awards },
                AllAvailableAwards = awards
            };

            return View(uvm);
        }


        public ActionResult Create()
        {
            var awards = logic.GetAllAwards().Select(a => new AwardViewModel(a.Title, a.Description) { Id = a.AwardId }).ToList();
            var uvm = new UserAndAwardsModel
            {                
                AllAvailableAwards = awards
            };

            return View(uvm);
        }

        public ActionResult Delete(int userId)
        {
            var deletingUser = logic.GetAllUsers().FirstOrDefault(u => u.Id == userId);
            logic.RemoveUser(deletingUser);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Save(UserAndAwardsModel userModel)
        {
			if (userModel != null)
			{

					// update
					var currentUser = logic.GetAllUsers().FirstOrDefault(u => u.Id == userModel.User.Id);

					if (currentUser != null)
					{
						var user = userModel.ToUser(userModel.User);
						currentUser.FirstName = user.FirstName;
						currentUser.LastName = user.LastName;
						currentUser.Birthdate = user.Birthdate;
						currentUser.Awards = user.Awards;
                    logic.EditUser(currentUser, currentUser.Id);
					}
			}

			return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Add(UserAndAwardsModel userModel)
        {
            logic.AddUser(userModel.ToUser(userModel.User));

            return RedirectToAction("Index");

        }
    }
}