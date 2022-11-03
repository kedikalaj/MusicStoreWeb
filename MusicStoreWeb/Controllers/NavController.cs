using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using System.Linq;

namespace MusicStoreWeb.Controllers
{
    public class NavController : Controller
    {
        private ISongsRepository repository;
        public NavController(ISongsRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            
            ViewBag.SelectedCategory = category;

            IEnumerable<MusicStore.Domain.Entities.Genres> categories = repository.Songs
            .Select(x => x.Genre)
           .Distinct()
           .OrderBy(x => x).AsEnumerable();

                return PartialView("FlexMenu", categories);

        }
    }
}
