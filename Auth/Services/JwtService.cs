using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _confi;

        public JwtService(IConfiguration configuration)
        { 
            this._confi=configuration;
        }
        string IJwtService.GenerateToken(string username, string role)
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)

            };

            var key =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_confi["jwt:key"]));
            var cresd = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer : _confi["jwt:issuer"],
                audience: _confi["jwt:audience"],
                claims:claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_confi["Jwt:DurationInMinutes"])),
                signingCredentials: cresd
            );

            return new JwtSecurityTokenHandler().WriteToken(token);




        }

        
    }
}
