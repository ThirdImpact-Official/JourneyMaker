using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class SoundEffectRepository : Repository<SoundEffect>, ISoundEffectRepository
    {
        private readonly DataContext _context;

        public SoundEffectRepository(DataContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
