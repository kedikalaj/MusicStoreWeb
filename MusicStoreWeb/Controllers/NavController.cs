using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using System.Linq;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Concrete;

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

            IEnumerable<string> categories = genresRepository.Genres
           .Select(x => x.Name)
           .Distinct()
           .OrderBy(x => x).AsEnumerable();

                return PartialView("FlexMenu", categories);

        }
    }
}
