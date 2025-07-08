using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        private readonly DataContext _dataContext;

        public MusicRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
