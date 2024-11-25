using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RealTimeChat.ApplicationCore.Configuration;
using RealTimeChat.ApplicationCore.DTOs;
using RealTimeChat.ApplicationCore.DTOs.User;
using RealTimeChat.ApplicationCore.Entities;
using RealTimeChat.ApplicationCore.Interfaces.Infrastructure;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealTimeChat.Infrastructure.Identity
{
    internal class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtConfiguration _configuration;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager, JwtConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(LoginDto loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if(user is null)
                return new ServiceResponse<string>(false, null, "No existe una cuenta asociada a ese correo");

            var userWithPassword = await _userManager.CheckPasswordAsync(user, loginUser.Password);
            if(!userWithPassword)
                return new ServiceResponse<string>(false, null, "Correo y/o contraseña incorrecta/s");
      
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, false);
            if(!signInResult.Succeeded)
                return new ServiceResponse<string>(false, null, "Error en el servidor. Contacte con el soporte");

            string token = GetTokenJwt(user);
            return new ServiceResponse<string>(true, token, null);
        }

        public async Task<ServiceResponse<LoginDto>> Register(RegisterDto registerUser)
        {
            var userByEmailOrUserName = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userByEmailOrUserName is not null)
                return new ServiceResponse<LoginDto>(false, null, "Correo ya en uso, elige otro");

            userByEmailOrUserName = await _userManager.FindByNameAsync(registerUser.UserName);
            if (userByEmailOrUserName is not null)
                return new ServiceResponse<LoginDto>(false, null, "Nombre de usuario ya en uso, elige otro");

            User user = new User()
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName,
                Name = registerUser.Name,
                LastName = registerUser.LastName,
                PhotoUrl= "https://thumbs.dreamstime.com/b/icono-del-perfil-avatar-defecto-105356015.jpg"
            };

            var createResult = await _userManager.CreateAsync(user, registerUser.Password);
            if (!createResult.Succeeded)
                return new ServiceResponse<LoginDto>(false, null, "Error en el servidor. Contacte con el soporte");

            return new ServiceResponse<LoginDto>(true, new LoginDto(user.Email, ""), null);
        }

        public string? GetTokenJwt(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_configuration.Key);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(type:ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim("photoUrl", user.PhotoUrl?? ""),
                new Claim("name", user.Name),
                new Claim("lastName", user.LastName),
                new Claim("userName", user.UserName!)
            };
            var jwtToken = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                expires: DateTime.UtcNow.AddHours(_configuration.DurationInHours)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        public async Task<ServiceResponse<bool>> Logout()
        {
            await _signInManager.SignOutAsync();
            return new ServiceResponse<bool>(true, true, null);
        }
    }
}
