using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Models.Favorite;
using SoundBoard.Repository.Favorite;

namespace SoundBoard.Repository
{
    public class FavoriteMusicRepository : Repository<FavoriteMusic>, IFavoriteMusicRepository
    {
        private readonly DataContext dataContext;

        public FavoriteMusicRepository(DataContext dataContext)
            : base(dataContext) => this.dataContext = dataContext;
    }
}
