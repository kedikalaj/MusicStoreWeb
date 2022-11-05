using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using System.Linq;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Concrete;
using MusicStoreWeb.Models;

namespace MusicStoreWeb.Controllers
{
    public class NavController : Controller
    {
        private ISongsRepository songsRepository;
        private IGenresRepository genresRepository;



        public NavController(ISongsRepository SongRepo, IGenresRepository GenresRepo)
        {
            songsRepository = SongRepo;
            genresRepository = GenresRepo;
        }
        public PartialViewResult Menu(string category = null)
        {
            
            ViewBag.SelectedCategory = category;

            List<GenreMenuItemModel> categories = genresRepository.Genres
           .Select(x => new GenreMenuItemModel()
           {
               Id = x.ID,
               Name = x.Name
           })
           .OrderBy(x => x.Name).ToList();

                return PartialView("FlexMenu", categories);

        }
    }
}
