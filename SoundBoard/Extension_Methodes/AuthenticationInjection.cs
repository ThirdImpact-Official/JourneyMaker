using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SoundBoard.Models.Datatype;

namespace SoundBoard.Extension_Methodes
{
    public static class AuthenticationInjection
    {
        /// <summary>
        /// add authentication to the dependency injection
        /// tokenServices 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<JwtConfiguration>();
            //injection du services
            services.AddSingleton<TokenService>();

            JwtConfiguration jwtConfiguration= new JwtConfiguration(configuration);

            services.AddAuthentication(er =>
            {
                er.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                er.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Secret))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        string? Authorization = context.Request.Headers["Authorization"];
                        if (string.IsNullOrEmpty(Authorization))
                        {
                            context.NoResult();
                        }
                        else
                        { 
                            context.Token = Authorization.Replace("Bearer ",string.Empty);
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            
            services.AddAuthorization();
            return services;
        }
    }
}