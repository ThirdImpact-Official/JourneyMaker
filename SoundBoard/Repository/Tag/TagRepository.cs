using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Repository
{
    public class TagRepository : Repository<UserTag>, ITagRepository
    {
        private readonly DataContext dataContext;

        public TagRepository(DataContext dataContext)
            : base(dataContext) => this.dataContext = dataContext;
    }
}
