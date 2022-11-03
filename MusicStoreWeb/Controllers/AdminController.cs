using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;


using MusicStore.Domain.Entities;

namespace MusicStoreWeb.Controllers
{
    [Authorize]
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
            Songs song = repository.Songs
            .FirstOrDefault(p => p.ID == SongID);
            return View(song);
        }
        [HttpPost]
        public ActionResult Edit(Songs product, HttpPostedFileBase image = null)
        {


            {
                var list = new List<string>() { "Pop", "Rock" };
                ViewBag.list = list;
                ViewBag.list = list.ToList();



                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        product.ImageMimeType = image.ContentType;
                        product.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                    }
                    
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

        public ViewResult Create()
        {
            return View("Edit", new Songs());
        }
        [HttpPost]
        public ActionResult Delete(int SongId)
        {
            Songs deletedProduct = repository.DeleteProduct(SongId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }


    }
    public class Genres
    {
        public Genre Genress { get; set; }
    }

    public enum Genre
    {
        Pop,
        Rock
    }
}