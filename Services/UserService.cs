using AuthApi.Models;
using AuthApi.Models.DTOs;
using AuthApi.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;


namespace AuthApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public AuthResponse Register(RegisterRequest request)
        {
            // Check if username already exists
            if (_userRepository.GetByUsername(request.Username) != null)
            {
                return new AuthResponse { Success = false, Message = "Username already exists" };
            }

            var newUser = new User
            {
                Username = request.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            _userRepository.Add(newUser);
            _userRepository.SaveChanges();

            return new AuthResponse { Success = true, Message = "User registered successfully" };
        }

        public AuthResponse Login(LoginRequest request)
        {
            var user = _userRepository.GetByUsername(request.Username);


            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return new AuthResponse { Success = false, Message = "Invalid username or password" };
            }

            var token = GenerateJwtToken(user.Username);
            return new AuthResponse { Success = true, Message = "Login successful", Token = token };
        }

        private string GenerateJwtToken(string username)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
