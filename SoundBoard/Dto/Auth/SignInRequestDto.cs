using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Dto.Auth
{
    public class SignInRequestDto
    {

        public string Email { get; set; }= string.Empty;
        public string Password { get; set; }= string.Empty;
        public string UserName { get; set; }= string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}