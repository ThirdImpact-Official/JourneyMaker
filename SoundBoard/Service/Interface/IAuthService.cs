using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoundBoard.Models.Datatype;

namespace SoundBoard.Service.Interface
{
    public interface IAuthService
    {
        /// <summary>
        /// permet a un utilisateur de s'inscrire au seinde l'application
        /// </summary>
        /// <returns></returns>
        Task<AuthResponse> SignIn();
        /// <summary>
        /// permet a un utilisateur de se connecter au seinde l'application
        /// </summary>
        /// <returns></returns>
        Task<AuthResponse> Login();
        /// <summary>
        /// permet a un utilisateur de se deconnecter au seinde l'application
        /// </summary>
        /// <returns></returns>
        Task<AuthResponse> Logout();

    }
}