using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SoundBoard.Dto.Auth;
using SoundBoard.Models.Datatype;

namespace SoundBoard.Service.Business_Service
{
    public class AuthService : IAuthService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="userManager"></param>
        public AuthService(UnitOfWork unitOfWork, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            this.unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._tokenService = tokenService;
        }

        /// <summary>
        /// permet a un utilisateur de s'inscrire au seinde l'application
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<AuthResponse>> SignIn(SignInRequestDto signInRequestDto)
        {
            AuthResponse authResponse = new AuthResponse();
            try
            {
                //verification de proprietes de l'utilisateur
                User? ExistUser = await _userManager.FindByEmailAsync(signInRequestDto.Email);

                if (ExistUser != null)
                {
                    return BussinessManager.Failure<AuthResponse>(Errortype.Bad, "L'utilisateur existe deja");
                }
                User userEntity = new User()
                {

                    UserName = signInRequestDto.UserName,
                    LastName = signInRequestDto.LastName,
                    FirstName = signInRequestDto.FirstName,
                    Email = signInRequestDto.Email,
                    PasswordHash = signInRequestDto.Password,

                };

                await _userManager.CreateAsync(userEntity, signInRequestDto.Password);
                //enregistrement de l'utilisateur

                return BussinessManager.Success(authResponse);
            }
            catch (System.Exception ex)
            {
                return BussinessManager.Failure<AuthResponse>(Errortype.Bad, ex.Message);
            }
        }
        /// <summary>
        /// permet a un utilisateur de se connecter au seinde l'application
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<AuthResponse>> Login(LoginRequestDto loginRequestDto)
        {
            AuthResponse authResponse = new AuthResponse();
            try
            {
                //verificationde l'existence de l'utilisateur
                User user = await _userManager.FindByEmailAsync(loginRequestDto.Email)
                    ?? throw new Exception("L'utilisateur n'existe pas");

                // verifier si l'utilisateur peut se connecter
                bool canSignUp = await _signInManager.CanSignInAsync(user);

                if (!canSignUp)
                {
                    return BussinessManager.Failure<AuthResponse>(Errortype.Bad, "L'utilisateur ne peut pas se connecter");
                }

                //authentification
                await _signInManager.SignInAsync(user, true, loginRequestDto.Password);

                //génération du jwt token 

                authResponse.Message = "Connexion reussie";
                authResponse.Refresh = _tokenService.GenerateRefreshToken().Result;
                authResponse.Success = true;
                

                return BussinessManager.Success(authResponse);

            }
            catch (System.Exception ex)
            {
                return BussinessManager.Failure<AuthResponse>(Errortype.Bad, ex.Message);
            }
        }
        /// <summary>
        /// permet a un utilisateur de se deconnecter au seinde l'application
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<AuthResponse>> Logout()
        {
            try
            {

            }
            catch (System.Exception ex)
            { 
                return BussinessManager.Failure<AuthResponse>(Errortype.Bad,ex.Message);
            }
        }
    }
}