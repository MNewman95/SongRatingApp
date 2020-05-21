using System;
using System.Collections.Generic;

namespace SongRatingApp.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int songID { get; set; }
        public string userName { get; set; }
        public int ratingValue { get; set; }
        public Songs Song { get; set; }

        public List<int> Range { get; set; }
    }
}
