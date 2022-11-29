using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStoreWeb.Models;

namespace SportsStore.WebUI.Controllers
{
    public class MusicController : Controller
    {
        private ISongsRepository repository;
        private IGenresRepository genresRepository;
        public int PageSize = 6;
        public MusicController(ISongsRepository productRepository, IGenresRepository genresRepository)
        {
            this.repository = productRepository;
            this.genresRepository = genresRepository;
        }
        public ViewResult List(int? category, int page = 1)
        {
            var songs = repository.Songs
                .Where(p => category == 0 || p.GenreID == category)
                .OrderBy(p => p.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize).ToList();
            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize
            };
            pagingInfo.TotalItems = category == 0 ?
                repository.Songs.Count() :
                repository.Songs.Where(e => e.GenreID == category).Count();

            SongsListViewModel model = new SongsListViewModel
            {
                Songs = songs, 
                PagingInfo = pagingInfo,
                CurrentCategory = category
            };

            return View(model);
    }
        public FileContentResult GetImage(int ID)
        {
            Songs prod = repository.Songs
            .FirstOrDefault(p => p.ID == ID);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public ActionResult Details(int ID = 0)
        {
            if (ID == 0)
                throw new ArgumentNullException("Ablum is not found");

            var song = repository.Songs.SingleOrDefault(a => a.ID == ID);
            if (song == null)
                throw new ArgumentNullException("Ablum is not found");

            var model = new Songs()
            {
                ID = song.ID,
                Name = song.Name,
                Author = song.Author,
                Price = song.Price,
                GenreID = song.GenreID,
                Length = song.Length,
                ImageData = song.ImageData,
                ImageMimeType = song.ImageMimeType
            };

            return View(model);
        }

    }
}