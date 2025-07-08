using Microsoft.EntityFrameworkCore;
using SoundBoard.Repository;
using SoundBoard.Repository.Cycle;
using SoundBoard.Repository.Favorite;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Extension_Methodes
{
    public static class DependencyInjection
    {
        #region database
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("default"))
            );

            return services;
        }
        #endregion
        #region repository
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //cycle
            services.AddScoped<IMusicCycleRepository, MusicCycleRepository>();
            services.AddScoped<IMusicCycleItemRepository, MusicCycleItemRepository>();
            services.AddScoped<IMusicCycleTransitionRepository, MusicCycleTransitionRepository>();
            //Music
            services.AddScoped<IMusicRepository, IMusicRepository>();
            services.AddScoped<IMusicLibraryRepository, MusicLibraryRepository>();
            //Playlist
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            //soundeffect
            services.AddScoped<ISoundEffectRepository, SoundEffectRepository>();
            services.AddScoped<ISoundEffectLibraryRepository, SoundEffectLibraryRepository>();
            //tag
            services.AddScoped<ITagRepository, TagRepository>();
            //favorite
            services.AddScoped<IFavoriteMusicRepository, FavoriteMusicRepository>();
            services.AddScoped<IFavoriteSoundEffectRepository, FavoriteSoundEffectRepository>();
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        #endregion
    }
}
