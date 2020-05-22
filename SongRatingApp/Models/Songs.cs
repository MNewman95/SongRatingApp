using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRatingApp.Models
{
    public class Songs
    {
        public int songID { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public int playlistID { get; set; }
        public int rating { get; set; }

        public Rating SongRating { get; set; }
    }
}