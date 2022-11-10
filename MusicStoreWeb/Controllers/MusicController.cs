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
        public int PageSize = 4;
        public MusicController(ISongsRepository productRepository)
        {
            this.repository = productRepository;
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

    }
}