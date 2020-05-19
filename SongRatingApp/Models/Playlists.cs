using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRatingApp.Models
{
    public class Playlists
    {
        public int playlistID { get; set; }
        public string playlistName { get; set; }
        public int playlistRating { get; set; }
        public IEnumerable<Songs> PlaylistSongs { get; set; }
        
       

    }
}
