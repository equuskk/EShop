using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EShop.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Application.Users.Services
{
    public class GenerateTokenService
    {
        private readonly IConfiguration _configuration;

        public GenerateTokenService(IConfiguration configuration) //TODO: IOptions
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(ShopUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtAuth:ExpireDays"]));

            var token = new JwtSecurityToken(
                                             _configuration["JwtAuth:Issuer"],
                                             _configuration["JwtAuth:Issuer"],
                                             claims,
                                             expires: expires,
                                             signingCredentials: creds
                                            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}