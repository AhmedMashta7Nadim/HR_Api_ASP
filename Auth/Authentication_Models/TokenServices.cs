using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Models.Model;

namespace Auth.Authentication_Models
{
    public class TokenServices : ITokenServices
    {
        public async Task<string> GeneretorToken(Account user)
        {
            var claimsLista = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim("EmployeeId",user.EmployeeId.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var crads = new SigningCredentials(JwtServices.getSecurityKey(), SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken
                (
                issuer: JwtServices.DominServer,
                audience: JwtServices.DominServer,
                claims: claimsLista,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: crads
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
