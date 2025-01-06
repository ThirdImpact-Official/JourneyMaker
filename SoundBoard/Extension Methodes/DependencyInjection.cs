using Microsoft.EntityFrameworkCore;
using SoundBoard.Repository;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Extension_Methodes
{
    public static class DependencyInjection
    {
        #region database
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataContext>(options => 
                    options.UseSqlServer(configuration.GetConnectionString("default")));

            return services;
        }
        #endregion
        #region repository
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ISoundFileRepository, SoundFileRepository>();
            services.AddScoped<ISoundLibraryRepository, SoundLibraryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
        #endregion
    }
}
