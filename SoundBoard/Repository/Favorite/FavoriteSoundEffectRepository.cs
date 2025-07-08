using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Models.Favorite;

namespace SoundBoard.Repository.Favorite
{
    public class FavoriteSoundEffectRepository
        : Repository<FavoriteSoundEffect>,
            IFavoriteSoundEffectRepository
    {
        private readonly DataContext dataContext;

        public FavoriteSoundEffectRepository(DataContext dataContext)
            : base(dataContext) => this.dataContext = dataContext;
    }
}
