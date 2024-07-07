using HoPe.Core.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HoPe.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeSha256(string passWord)
        {
            using (SHA256 sha256Hash = SHA256.Create())//Inicializando o método do sha256 Create
            {
                //ComputeHash - retorna byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passWord));

                //Converte byte array para string
                StringBuilder builder = new StringBuilder();//concatenação de string

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));// 2x faz com que sseja convertido em representação hexadecimal
                }

                return builder.ToString();
            }
        }

        public string GenerateToken(string user, string role)
        {
            var key = _configuration["JWT:Key"];
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim> { new Claim("userName", user), new Claim(ClaimTypes.Role, role) };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
