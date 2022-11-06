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
        private IGenresRepository genresRepository;
        public AdminController(ISongsRepository SongRepo, IGenresRepository GenresRepo)
        {
            repository = SongRepo;
            genresRepository = GenresRepo;
        }
        public ViewResult Index()
        {
            return View(repository.Songs);
        }
        public ViewResult Edit(int? ID)
        {
            Songs song = repository.Songs
            .FirstOrDefault(p => p.ID == ID);
            return View(song);
        }
        [HttpPost]
        public ActionResult Edit(Songs product, HttpPostedFileBase image = null)
        {
            {
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
        public ActionResult SaveGenre(Genres product)
        {

                if (ModelState.IsValid)
                {

                genresRepository.SaveGenre(product);
                    TempData["message"] = string.Format("{0} has been saved", product.Name);
                    return RedirectToAction("Index");
                }
                else
                {


                    return View(product);

                }

            
        }

        public ViewResult Create()
        {
            return View("Edit", new Songs());
        }
        public ActionResult CreateGenre()
        {
            return View("SaveGenre", new Genres());
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Songs deletedProduct = repository.DeleteProduct(ID);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }


    }
    public class Genree
    {
        public Genrees Genrees { get; set; }
    }

    public enum Genrees
    {
        Pop,
        Rock
    }
}