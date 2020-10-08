using System;
using System.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace FeriaVirtual.API.Controllers {

    internal static class TokenGenerator {

        public static string GenerateTokenJwt(string username) {
            string secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            string audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            string issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            string expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name,username) });

            // create token to the user
            System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            string jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

    }
}