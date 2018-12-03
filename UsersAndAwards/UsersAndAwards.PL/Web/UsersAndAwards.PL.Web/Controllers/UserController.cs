
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
                .Select(u => new UserViewModel(u.FirstName, u.LastName, u.Birthdate, u.Awards))
                .ToList();

            return View(users);

        }

        public ActionResult Edit(int userId)
        {
            var user = logic.GetAllUsers().FirstOrDefault(u => u.Id == userId);


            return View(user);
        }

        public ActionResult Add()
        {
            return View("Edit", null);
        }

        public ActionResult Delete(int userId)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Save(UserViewModel userModel)
        {
			if (userModel != null)
			{
				if (userModel.Id == default(int))
				{
                    // add
                    
                    logic.AddUser(userModel.ToUser(userModel));
				}
				/*else
				{
					// update
					var currentUser = users.FirstOrDefault(u => u.Id == userModel.Id);
					if (currentUser != null)
					{
						var user = userModel.ToUser();
						currentUser.FirstName = user.FirstName;
						currentUser.LastName = user.LastName;
						currentUser.Birthdate = user.Birthdate;
						currentUser.Rewards = user.Rewards;
					}
				}*/
			}

			return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
    }
}