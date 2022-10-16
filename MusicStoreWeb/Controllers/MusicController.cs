﻿using System;
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
        public ViewResult List(int page = 1)
        {
            SongsListViewModel model = new SongsListViewModel
            {
                Songs = repository.Songs
            .OrderBy(p => p.SongID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize), PagingInfo = new PagingInfo{
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Songs.Count()
                }
        };

            return View(model);
    }
}
}