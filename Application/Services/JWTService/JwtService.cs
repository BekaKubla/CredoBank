using KredoBank.Application.Services.JWTService.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KredoBank.Application.Services.JWTService
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateUserToken(string userName, int id)
        {
            var jwt = _configuration.GetSection("Jwt").Get<JWTModel>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("Id",id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId,userName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(jwt.Issuer, jwt.Audience, claims, expires: DateTime.Now.AddMinutes(20), signingCredentials: signIn);
            var resultToken = new JwtSecurityTokenHandler().WriteToken(token);

            return resultToken;
        }
    }
}
