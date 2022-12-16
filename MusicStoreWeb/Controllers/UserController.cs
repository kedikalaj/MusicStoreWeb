using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Models;
using MusicStoreWeb.Models;


namespace MusicStoreWeb.Controllers
{
    public class UserController : Controller
    {

       IUserRepository userRepository;
        public UserController(IUserRepository userRepo)
        {
            userRepository = userRepo;
        }

        public ActionResult UserSignup()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }

        public ActionResult Login(User users, string returnUrl)
        {
            string username = users.Username;
            string passwrd = users.Password;

            var user = userRepository.User
               .Where(p => p.Username == username && p.Password ==passwrd) .FirstOrDefault();

            return Redirect(returnUrl ?? Url.Action("Index", "Admin", user));
        }
        public ActionResult Register(User user)
        {

            userRepository.SaveUser(user);
           
            TempData["message"] = string.Format("Wellcome, {0}", user.Username);
            

            return Redirect(Url.Action("List", "Music", new { }));
        }
    }
}