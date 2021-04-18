using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TheLibrary.Infrastructure.Configurations;

namespace TheLibrary.Api.Configurations
{
    public static class AuthenticationSetup
    {
        public static void AddAuthenticationSetup(this IServiceCollection services, string secretValue, JwtSettings jwtSettings)
        {
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var parameters = jwt.TokenValidationParameters;
                jwt.SaveToken = true;
                parameters.ValidAudience = jwtSettings.Audience;
                parameters.ValidIssuer = jwtSettings.Issuer;
                parameters.ValidateIssuerSigningKey = true;
                parameters.IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.ASCII.GetBytes(secretValue));
                parameters.ValidateLifetime = true;
            });
        }
    }
}
