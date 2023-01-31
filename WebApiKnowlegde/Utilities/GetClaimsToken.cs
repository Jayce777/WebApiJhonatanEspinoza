
using System.IdentityModel.Tokens.Jwt;

namespace WebApiKnowlegde.Utilities
{
    public class GetClaimsToken
    {
        public string readClaimsFromToken(string token)
        {
            token = token.Replace("Bearer ", "").Trim();

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            return jwt.Claims.First(c => c.Type == "email").Value;
        }
    }
}
