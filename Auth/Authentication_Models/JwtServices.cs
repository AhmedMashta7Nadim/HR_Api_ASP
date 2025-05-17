using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
namespace Auth.Authentication_Models
{
    public static class JwtServices
    {
        private const string Key = "77777777777777999999999999999999888888888888887777777777asaskckjskcbksdckbckbkscc";
        internal const string DominServer = "https://localhost:7223";
        public static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateActor = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey=true,
                ValidIssuer= DominServer,
                ValidAudience= DominServer,
                IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
            };
        }
        public static SymmetricSecurityKey getSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
    }
}