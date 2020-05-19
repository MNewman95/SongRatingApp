using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SongRatingApp.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongsRepository repo;

        public SongController(ISongsRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Playlists()
        {
            var playlists = repo.GetAllPlaylists();

            return View(playlists);
        }

        public IActionResult Songs()
        {
            var songs = repo.GetAllSongs();

            return View(songs);
        }
    }
}