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
            return _conn.Query<Songs>("SELECT * FROM Songs;");
        }

        public IEnumerable<Playlists> GetAllPlaylists()
        {
            return _conn.Query<Playlists>("SELECT * FROM Playlists;");
        }
    }
}
