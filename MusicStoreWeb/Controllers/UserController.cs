using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Models;
using MusicStoreWeb.Models;
using System.Web.UI;

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

        public ActionResult Login(User users)
        {
            string username = users.Username;
            string passwrd = users.Password;

            var user = userRepository.User
               .Where(p => p.Username == username && p.Password ==passwrd) .FirstOrDefault();

            TempData["message"] = string.Format("Welcome {0}", user.Username);


            HttpCookie UserCookie = new HttpCookie("username", user.Username);
            UserCookie.Expires.AddHours(3);
            



            HttpContext.Response.SetCookie(UserCookie);
           



            return Redirect( Url.Action("List", "Music", user));
        }
        public ActionResult Register(User user)
        {
            List<string> usernames = userRepository.GetUser();
            bool nonRepeated = true;
            foreach (string p in usernames)
            {
                if(p == user.Username)
                {
                    nonRepeated = false;
                }
            }

            if (nonRepeated)
            {
                userRepository.SaveUser(user);

                HttpCookie UserCookie = new HttpCookie("username", user.Username);
                UserCookie.Expires.AddHours(3);

                HttpContext.Response.SetCookie(UserCookie);
            }
            else
            {
                //alert showing that the username already exists
            }
          




            return Redirect(Url.Action("List", "Music", new { }));
        }

    }

}