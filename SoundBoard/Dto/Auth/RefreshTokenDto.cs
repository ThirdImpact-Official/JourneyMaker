using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Dto.Auth
{
    public class RefreshTokenDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}