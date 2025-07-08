using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        private readonly DataContext _context;

        public PlaylistRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
