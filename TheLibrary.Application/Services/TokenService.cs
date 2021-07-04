using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;
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
            var expirationDate = DateTime.Parse($"{DateTime.Now.AddDays(1).ToString("dd/MM/yyyy")} 00:00:00");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Login", user.Login),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("Active", user.Active.ToString()),
                    new Claim("ExpirationDate", expirationDate.ToString("dd/MM/yyyy HH:mm:ss"))
                }),
                Expires = expirationDate,
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwt.Audience,
                Issuer = jwt.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
