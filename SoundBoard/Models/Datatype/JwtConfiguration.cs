using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models.Datatype
{
    /// <summary>
    /// Configuration for jwt 
    /// </summary>
    public class JwtConfiguration
    {
        public string? Issuer { get; set; } = string.Empty;
        public string? Secret { get; set; } = string.Empty;
        public string? Audience { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }

        public JwtConfiguration(IConfiguration configuration)

        {
            var section = configuration.GetSection("Jwt");
            Issuer = section["Issuer"];
            Secret = section["Secret"];
            Audience = section["Audience"];
            DurationInMinutes = Convert.ToInt32(section["DurationInMinutes"]);
        }
    }
}