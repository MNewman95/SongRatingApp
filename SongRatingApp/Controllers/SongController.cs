using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongRatingApp.Models;

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
            foreach (var x in songs)
            {
                try
                {
                    var rating = repo.GetAvg(x.songID);
                    x.AverageRating = rating.AverageRating;
                }
                catch (Exception e)
                {
                   
                }

            }


            return View(songs);
        }

        public IActionResult InsertRating(int id)
        {
            var song = repo.GetSong(id);

            var valueRange = new List<int>() { 1, 2, 3, 4, 5 };

            song.SongRating = new Rating();

            song.SongRating.Range = valueRange;

            return View(song);
        }

        public IActionResult InsertRatingToDatabase(Rating rating)
        {
            repo.InsertRating(rating);

            return RedirectToAction("Songs");
        }
    }
}