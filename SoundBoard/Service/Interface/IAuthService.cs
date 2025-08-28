using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Dto.Auth;
using SoundBoard.Models.Datatype;

namespace SoundBoard.Service.Interface
{
    public interface IAuthService
    {
        /// <summary>
        /// permet a un utilisateur de s'inscrire au seinde l'application
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<AuthResponse>> SignIn(SignInRequestDto signInRequestDto);
        /// <summary>
        /// permet a un utilisateur de se connecter au seinde l'application
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<AuthResponse>> Login(LoginRequestDto loginRequestDto);
        /// <summary>
        /// permet a un utilisateur de se deconnecter au seinde l'application
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<AuthResponse>> Logout();

    }
}