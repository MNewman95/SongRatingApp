using SongRatingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRatingApp
{
    public interface ISongsRepository
    {
        public IEnumerable<Songs> GetAllSongs();
        public IEnumerable<Playlists> GetAllPlaylists();
        public Songs GetSong(int songID);
        public void InsertRating(Rating rating);
    }
}
