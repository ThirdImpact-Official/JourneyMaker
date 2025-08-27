using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Extension_Methodes
{
    public static class CacheDependencyInjection
    {
        /// <summary>
        /// add cache to the dependency injection
        /// </summary>
        /// <param name="service"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddCacheKeyDb(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration.GetConnectionString("keydb");
            });

            return service;
        }
    }
}