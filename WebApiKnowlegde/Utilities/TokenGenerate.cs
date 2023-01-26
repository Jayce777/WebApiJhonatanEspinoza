using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiKnowlegde.DTO;

namespace WebApiKnowlegde.Utilities
{
    public class TokenGenerate
    {
        public TokenGenerate(string Key)
        {
            this.Key = Key;
        }

        public string Key { get; }

        public responseAutentication tokenCreate(userCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email",userCredentials.Email)
            };
            var keyCreate = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(keyCreate, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(issuer: null,audience:null,claims:claims,
                notBefore:null,expires:expiration,signingCredentials:credentials);

            return new responseAutentication()
            {
                ExpireIn = expiration,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
