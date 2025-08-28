using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SoundBoard.Dto.Auth;
using SoundBoard.Dto.User;
using SoundBoard.Models.Datatype;
using SoundBoard.Repository.Interface;

namespace SoundBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        public UsersController(IUserRepository repository,IAuthService authService)
        {
            _authService = authService;
            _userRepository = repository;
        }
        /// <summary>
        /// Sign in method For Sign in a user
        /// </summary>
        /// <param name="signInDto"></param>
        /// <returns></returns>
        [HttpGet("signin")]
        public async Task<ActionResult<ServiceResponse<AuthResponse>>> SignIn([FromBody] SignInRequestDto signInDto)
        {
            try
            {
                ServiceResponse<AuthResponse> response = await _authService.SignIn(signInDto);
                return HttpManager.HandleRequest(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ServiceResponse<AuthResponse> { Success = false, Message = ex.Message,Error = Errortype.Bad});
            }
        }
        /// <summary>
        /// Login method For login a user
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpGet("login")]
        public async Task<ActionResult<ServiceResponse<AuthResponse>>> Login([FromBody] LoginRequestDto loginDto)
        {
            try
            {
                ServiceResponse<AuthResponse> response = await _authService.Login(loginDto);
                return HttpManager.HandleRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<AuthResponse> { Success = false, Message = ex.Message , Error = Errortype.Bad});
            }
        }
        /// <summary>
        /// Logout method For logout a user
        /// </summary>
        /// <returns></returns>
        [HttpGet("logout")]
        public async Task<ActionResult<ServiceResponse<AuthResponse>>> Logout()
        {
            try
            {
                ServiceResponse<AuthResponse> response = await _authService.Logout();
                return HttpManager.HandleRequest(response);
            }
            catch (System.Exception ex)
            {
                 return BadRequest(new ServiceResponse<AuthResponse> { Success = false, Message = ex.Message });
            }
        }
    }
}
