using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using InfraStractur.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Model;

namespace Auth.Authentication_Models
{
    public class TokenServices : ITokenServices
    {
        private readonly HR_Connect context;

        public TokenServices()
        {

        }
        public TokenServices(HR_Connect context)
        {
            this.context = context;
        }
        public async Task<string> GeneretorToken(LogIn userLogIn)
        {

            var user = await context.accounts.FirstOrDefaultAsync(
                    x => x.UserName == userLogIn.UserName && x.Password == userLogIn.Password
                    );
            if (user == null)
            {
                return null;
            }
            var claimsLista = new[]
            {
                //new Claim(ClaimTypes.Role, "Admin"),

                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim("EmployeeId",user.EmployeeId.ToString()),
                new Claim("Role",user.Role.ToString()),
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
