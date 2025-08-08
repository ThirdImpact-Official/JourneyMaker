using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Service.Interface
{
    public interface ITokenService
    {
        /// <summary>
        /// Generate jwt token for a user 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> Generatetoken(User user);
        /// <summary>
        /// Validate jwt token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<bool> ValidateToken(string token);
        /// <summary>
        /// Generate refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<string> GenerateRefresh(string refreshToken);
        /// <summary>
        /// Validate refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<bool> ValidateRefresh(string refreshToken);
    }
}