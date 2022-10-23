using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Abstract;
using System.Linq;
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
        public ViewResult Edit(int SongsId)
        {
            Song product = repository.Songs
            .FirstOrDefault(p => p.SongID == SongsId);
            return View(product);
        }
    }
}