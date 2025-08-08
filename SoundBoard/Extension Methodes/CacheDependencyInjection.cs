using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Extension Methodes
{
    public static class CacheDependencyInjection
    {
        public static IServiceCollection AddCacheKeyDb(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddStackExchangeRedisCache(opt => {
                opt.Configuration= configuration.GetConnectionString("keydb");
            });
            
            return service
        }
    }
}