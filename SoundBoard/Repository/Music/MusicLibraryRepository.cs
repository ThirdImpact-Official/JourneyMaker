using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class MusicLibraryRepository : Repository<MusicLibrairies>, IMusicLibraryRepository
    {
        private readonly DataContext _dataContext;

        public MusicLibraryRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
