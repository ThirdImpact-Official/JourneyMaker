using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class SoundEffectLibraryRepository
        : Repository<SoundEffectLibrary>,
            ISoundEffectLibraryRepository
    {
        private readonly DataContext dataContext;

        public SoundEffectLibraryRepository(DataContext dataContext)
            : base(dataContext) => this.dataContext = dataContext;
    }
}
