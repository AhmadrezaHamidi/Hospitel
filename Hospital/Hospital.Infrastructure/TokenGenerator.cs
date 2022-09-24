using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Hospital.Core;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Infrastructure
{
    public class TokenGenerator
    {
        private string _patern = "akndgakl98qauhf9qhwhasufh9ush0SHF08ASHFAUHSF8";
        public string GetToken(UserEntity user)
        {


        var Claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
            new Claim(ClaimTypes.Name , user.FirstName),
            new Claim(ClaimTypes.SerialNumber , user.NationaCode),
            new Claim(ClaimTypes.Role , user.Role)
        };

            var SecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_patern)
            );

            var signCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(Claims),
                Audience = "SampleJwtAudience",
                Issuer = "SampleJwtIssuer",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signCredentials,
                CompressionAlgorithm = CompressionAlgorithms.Deflate
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(descriptor);

            return tokenHandler.WriteToken(securityToken);

        }
    }
}