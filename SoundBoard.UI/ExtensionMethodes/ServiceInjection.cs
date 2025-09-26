
using Plugin.Maui.Audio;
using SoundBoard.UI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoard.UI.ExtensionMethodes
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientBuilder,HttpClientBuilder>();
            services.AddScoped<ISoundPlayService, SoundPlayService>();
            services.AddSingleton(AudioManager.Current);
            services.AddScoped<SoundPlayer>();
            services.AddSingleton<Footer>();
            return services;
        }
    }
}
