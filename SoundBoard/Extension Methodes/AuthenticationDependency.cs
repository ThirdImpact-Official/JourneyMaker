using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Extension_Methodes
{
    public static class AuthenticationDependency
    {
        /// <summary>
        /// add authentication to the dependency injection
        /// for Token management
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}