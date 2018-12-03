
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

        public static List<Award> awards = new List<Award>
        {
            new Award
            {
                Title = "Epipc",
                Description = "epic",
                Id = 0
            }
        };

        public static List<UserViewModel> users = new List<UserViewModel>
        {
            new UserViewModel
            {
                FirstName = "User1",
                LastName = "Us1",
                Birthdate = new DateTime(1990, 2, 1)
            },
            new UserViewModel
            {
                FirstName = "User2",
                LastName = "Us2",
                Birthdate = new DateTime(1990, 2, 1),
                Awards = awards,
                Id = 2
            }
        };

        public ActionResult Index()
        {
            try
            {
                return View((List<UsersAndAwards.PL.Web.Models.User>)Logic.GetAllUsers());
                //return View(users);
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Edit(int userId)
        {
           
            var currentUser = logic.GetAllUsers();//users.FirstOrDefault(u => u.Id == 2);
            var allAwards = logic.GetAllAwards();//awards;
            var model = new UserViewModel();
            model.Id = 2;
            model.FirstName = currentUser.FirstName;
            model.Awards = allAwards.Select(a => new UsersAndAwards.PL.Web.Models.Award{ IsAssigned = currentUser.Awards.Any(aw => aw.AwardId == a.AwardId) }).ToList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View("Edit", null);
        }

        public ActionResult Delete(int userId)
        {
            var currentUser = logic.GetAllUsers();// users.FirstOrDefault(u => u.Id == userId);
            if (currentUser != null)
            {
               // storage.RemoveUser(currentUser);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Save(UserViewModel userModel)
        {
            if (userModel != null)
            {
                if (userModel.Id == default(int))
                {
                    // add
                    //storage.EditUser(userModel as Entities.User, userModel.Id);
                }
                else
                {
                    // update
                    var currentUser = /*storage.GetAllUsers()*/users.FirstOrDefault(u => u.Id == userModel.Id);
                    if (currentUser != null)
                    {
                        var user = userModel.ToUser();
                        currentUser.FirstName = user.FirstName;
                        currentUser.LastName = user.LastName;
                        currentUser.Birthdate = user.Birthdate;
                        //currentUser.Awards = (List<Entities.Award>)user.Awards;
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}