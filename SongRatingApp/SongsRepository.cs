using Dapper;
using SongRatingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SongRatingApp
{
    public class SongsRepository : ISongsRepository
    {
        private readonly IDbConnection _conn;
        public SongsRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Songs> GetAllSongs()
        {
            return _conn.Query<Songs>("SELECT songs.*,playlists.PlaylistName FROM Songs LEFT JOIN playlists ON playlists.PlaylistID = songs.PlaylistID ;");
        }

        public IEnumerable<Playlists> GetAllPlaylists()
        {
            return _conn.Query<Playlists>("SELECT * FROM Playlists;");
        }

        public Songs GetSong(int songID)
        {
            return _conn.QuerySingle<Songs>("SELECT * FROM Songs WHERE SongID = @songID", new { songID = songID });
        }

        public void InsertRating(Rating rating)
        {
            _conn.Execute("INSERT INTO ratings (songID, userName, ratingValue) VALUES (@songID, @userName, @ratingValue);",
                new { songID = rating.songID, userName = rating.userName, ratingValue = rating.ratingValue });
        }
        public Songs GetAvg(int songID )
        {
           return _conn.QuerySingle<Songs>("select songs.Artist, songs.Name, avg(ratings.ratingValue) as AverageRating from ratings" +
                " inner join songs on songs.SongID = ratings.songID" +
                " where songs.SongID = @songID" +
                " group by songs.Artist, songs.Name" +
                " order by AverageRating desc; ", new {songID = songID });
        }
        //public Songs PlaylistName(int playlistID)
        //{
        //    return _conn.QuerySingle<Songs>("");
        //}
    }
}



