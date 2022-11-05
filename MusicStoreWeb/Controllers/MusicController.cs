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
        public ViewResult List(int? category, int page = 1)
        {
            SongsListViewModel model = new SongsListViewModel
            {
                Songs = repository.Songs
                .Where(p => category == 0 || p.GenreID == category)
                .OrderBy(p => p.ID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize), PagingInfo = new PagingInfo{
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                TotalItems = category == 0 ?
                repository.Songs.Count() :
                repository.Songs.Where(e => e.GenreID == category).Count()
                    
                },
            CurrentCategory = category
            };

            return View(model);
    }
        public FileContentResult GetImage(int SongId)
        {
            Songs prod = repository.Songs
            .FirstOrDefault(p => p.ID == SongId);
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