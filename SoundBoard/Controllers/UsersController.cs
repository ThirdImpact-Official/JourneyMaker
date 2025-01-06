using Microsoft.AspNetCore.Mvc;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericController<User>
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository repository) : base(repository)
        {
            _userRepository=repository;
        }
    }
}
