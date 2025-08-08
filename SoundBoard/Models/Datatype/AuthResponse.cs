using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Models.Datatype
{
    public class AuthResponse
    {
        // token 
        public string Token { get; set; } = string.Empty;
        //refresh token
        public string Refresh { get; set; }= string.Empty;
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public Errortype Errortype { get; set; }
    }
}