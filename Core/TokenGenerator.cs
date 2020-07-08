using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using webapi1.Models;

namespace webapi1.Core {
    public class TokenGenerator {
        private readonly IConfiguration _configuration;
        public TokenGenerator (IConfiguration configuration) {
            _configuration = configuration;
        }
        public string CreateToken (User user, List<Claim> claims) {
            // List<Claim> claims = new List<Claim> {
            //     new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
            //     new Claim (ClaimTypes.Name, user.UserName)
            // };

            SymmetricSecurityKey key = new SymmetricSecurityKey (Encoding.UTF8
                .GetBytes (_configuration.GetSection ("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

            Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor {
                Subject = new ClaimsIdentity (claims),
                Expires = DateTime.Now.AddDays (1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler ();
            SecurityToken token = tokenHandler.CreateToken (tokenDescriptor);

            return tokenHandler.WriteToken (token);
        }
    }
}