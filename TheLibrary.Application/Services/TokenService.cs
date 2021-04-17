using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheLibrary.Application.Interfaces;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.Configurations;

namespace TheLibrary.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IJwtSettings jwt;

        public TokenService(IJwtSettings jwt)
        {
            this.jwt = jwt;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwt.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Login", user.Login),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Active", user.Active.ToString())
                }),
                Expires = DateTime.Parse($"{DateTime.Now.AddDays(1).ToString("dd/MM/yyyy")} 00:00:00"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
