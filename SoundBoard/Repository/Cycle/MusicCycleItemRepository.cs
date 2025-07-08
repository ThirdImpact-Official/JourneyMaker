using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class MusicCycleItemRepository : Repository<MusicCycleItem>, IMusicCycleItemRepository
    {
        private readonly DataContext dataContext;

        public MusicCycleItemRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
