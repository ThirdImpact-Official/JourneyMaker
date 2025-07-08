using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository.Cycle
{
    public class MusicCycleRepository : Repository<MusicCycles>, IMusicCycleRepository
    {
        private readonly DataContext _datacontext;

        public MusicCycleRepository(DataContext datacontext)
            : base(datacontext)
        {
            _datacontext = datacontext;
        }
    }
}
