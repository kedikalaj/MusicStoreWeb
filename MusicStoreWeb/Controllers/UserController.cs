using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Models;


namespace MusicStoreWeb.Controllers
{
    public class UserController : Controller
    {

       IUserRepository userRepository;
        public UserController(IUserRepository userRepo)
        {
            userRepository = userRepo;
        }


        public ActionResult UserLogin()
        {
            return View();
        }
    }
}