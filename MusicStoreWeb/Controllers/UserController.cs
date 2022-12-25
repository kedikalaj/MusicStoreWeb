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
        ISongsRepository songsRepository;
        public UserController(IUserRepository userRepo, ISongsRepository songsRepository)
        {
            userRepository = userRepo;
            this.songsRepository = songsRepository;
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
              .Where(p => p.Username == username && p.Password == passwrd).FirstOrDefault();
            if (user!=null)
            {

            
            int rid = user.RoleID;

            if (rid==1)
            {
               
                TempData["message"] = string.Format("Welcome {0}", user.Username);

                HttpCookie UserCookie = new HttpCookie("fatcookie");
                UserCookie.Values.Add("username", user.Username.ToString());
                UserCookie.Values.Add("ID", user.ID.ToString());
                UserCookie.Values.Add("RID", user.RoleID.ToString());
                   

                    UserCookie.Expires.AddHours(3);

                HttpContext.Response.SetCookie(UserCookie);
                return Redirect(Url.Action("Index", "Admin", user));
            }
            else
            { 
                
                HttpCookie UserCookie = new HttpCookie("fatcookie");
                UserCookie.Values.Add("username", user.Username.ToString());
                UserCookie.Values.Add("ID", user.ID.ToString());
                UserCookie.Expires.AddHours(3);

                HttpContext.Response.SetCookie(UserCookie);
                return Redirect(Url.Action("List", "Music", user));
                
            }
            }
            else { return Redirect(Url.Action("List", "Music")); }
        }

        HttpCookie UserCookie;

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

                HttpCookie UserCookie = new HttpCookie("fatcookie");
                UserCookie.Values.Add("username", user.Username.ToString());
                UserCookie.Values.Add("ID", user.ID.ToString());
                UserCookie.Expires.AddHours(3);

                HttpContext.Response.SetCookie(UserCookie);
            }
            else
            {
                //alert showing that the username already exists
            }
          




            return Redirect(Url.Action("List", "Music", new { }));
        }
        public ActionResult Logout(Cart cart)
        {
            if (Request.Cookies["fatcookie"] != null)
            {
                Response.Cookies["fatcookie"].Expires = DateTime.Now.AddDays(-1);
            }
           
            if (cart != null) {

                try
                {
                    foreach (var s in cart.Lines)
                    {


                        int ID = s.Product.ID;
                        Songs product = songsRepository.Songs
                        .FirstOrDefault(p => p.ID == ID);
                        if (product != null)
                        {
                            cart.RemoveLine(product);
                        }


                    }
                }
                catch
                {

                }
               
            
            
            }
           


            return Redirect(Url.Action("List", "Music", new { }));
        }

    }

}