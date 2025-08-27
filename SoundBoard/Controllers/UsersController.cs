using Microsoft.AspNetCore.Mvc;
using SoundBoard.Dto.User;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController 
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository repository) 
        {
            _userRepository=repository;
        }
    }
}
