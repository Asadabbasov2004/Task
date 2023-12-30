using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.UserDtos;
using UdemyApp.Business.ExternalServices.Interface;
using UdemyApp.Core.Entities;

namespace UdemyApp.Business.ExternalServices.Implemantation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _confing;

        public TokenService(IConfiguration confing)
        {
            _confing = confing;
        }
        public TokenResponseDto CreateToken(AppUser user, int expireDate=60)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
             new Claim(ClaimTypes.Name ,user.UserName),
             new Claim(ClaimTypes.Email ,user.Email),
             new Claim(ClaimTypes.GivenName ,user.Name),
             new Claim(ClaimTypes.NameIdentifier ,user.Id),
            //new Claim(ClaimTypes.Role, "Admin"),
         };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confing.GetSection("Jwt:Key").Value));


            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            SecurityToken securityToken = new JwtSecurityToken(
            issuer: _confing.GetSection("Jwt:Issuer").Value,
            audience: _confing["Jwt:Audience"],
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(expireDate),
            signingCredentials: signingCred
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(securityToken);
            return new()
            {
                Token = token,
                ExpireDate = securityToken.ValidTo,
                UserName = user.UserName,
            };
        }
    }
}
