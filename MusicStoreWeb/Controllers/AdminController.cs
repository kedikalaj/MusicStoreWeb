using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;

using MusicStore.Domain.Entities;

namespace MusicStoreWeb.Controllers
{
    public class AdminController : Controller
    {
        private ISongsRepository repository;
        public AdminController(ISongsRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Songs);
        }
        public ViewResult Edit(int? SongID)
        {
            Song song = repository.Songs
            .FirstOrDefault(p => p.SongID == SongID);
            return View(song);
        }
        [HttpPost]
        public ActionResult Edit(Song product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
            return View(product);
            }
        }
    }
}