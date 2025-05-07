using Fullstack.Core.Models.DTOs.Fullstack.Core.Models.DTOs;
using Fullstack.Core.Models.DTOs;
using Fullstack.Core.Models;
using Fullstack.Core.Repositories;
using Fullstack.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Fullstack.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User> RegisterAsync(RegisterDTO model)
        {
            // בדיקה אם המשתמש קיים
            var existingUser = _userRepository.GetList()
                .FirstOrDefault(u => u.Email == model.Email || u.Username == model.Username);

            if (existingUser != null)
            {
                throw new Exception("Username or email already exists");
            }

            // יצירת משתמש חדש
            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                CreatedAt = DateTime.Now
            };

            return _userRepository.Add(user);
        }

        public async Task<string> LoginAsync(LoginDTO model)
        {
            // מציאת המשתמש לפי שם משתמש או אימייל
            var user = _userRepository.GetList()
                .FirstOrDefault(u =>
                    u.Email == model.UsernameOrEmail ||
                    u.Username == model.UsernameOrEmail);

            if (user == null)
                throw new Exception("User not found");

            // בדיקת סיסמה
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                throw new Exception("Invalid password");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"] ?? "your-secret-key-with-at-least-16-characters");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
