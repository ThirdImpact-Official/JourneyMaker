using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository.Cycle
{
    public class MusicCycleTransitionRepository
        : Repository<MusicCycleTransition>,
            IMusicCycleTransitionRepository
    {
        private readonly DataContext _dataContext; // data

        public MusicCycleTransitionRepository(DataContext datacontext)
            : base(datacontext)
        {
            _dataContext = datacontext;
        }
    }
}
