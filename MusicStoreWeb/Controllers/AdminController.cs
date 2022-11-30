using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;

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
            SongViewModel model = new SongViewModel();
            if(song != null)
            {
                model.Name = song.Name;
                model.Genres = new SelectList(genresRepository.Genres.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString()
                })
              .OrderBy(c => c.Text).ToList(), "Value", "Text");
            }

           



 // genresRepository.Genres.Select(c => new SelectListItem
 // {
 //     Text = c.Name,
 //     Value = c.ID.ToString()
 // }).OrderBy(c => c.Text).ToList(),
 //"Value", "Text")
 //);



            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SongViewModel product, HttpPostedFileBase image = null)
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
        public ViewResult EditGenre(int? ID)
        {
            Genres genres = genresRepository.Genres
            .FirstOrDefault(p => p.ID == ID);
            return View(genres);
        }
       
        

        public ViewResult Create()
        {
            SongViewModel model = new SongViewModel();
            model.Genres = new SelectList(genresRepository.Genres.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.ID.ToString()
            }));

            return View("Edit", model);
        }
        public ViewResult CreateG()
        {
            return View("SaveGenre", new Genres());
        }



        public ViewResult ListGenres()
        {
            return View(genresRepository.Genres);
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

        public ActionResult DeleteG(int ID)
        {
            Genres deletedProduct = genresRepository.DeleteGenre(ID);
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