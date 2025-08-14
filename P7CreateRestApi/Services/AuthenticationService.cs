using Microsoft.IdentityModel.Tokens;
using P7CreateRestApi.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace P7CreateRestApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<User> Users = new List<User>()
        {
            new User
            {
                Id = 1,
                UserName = "Admin",
                Password = "Admin5489?",
                Fullname = "Admin",
                Role = "Admin"
            },
            new User
            {
                Id = 2,
                UserName = "User",
                Password = "User5489?",
                Fullname = "User",
                Role = "User"
            }
        };

        public User Authenticate(string Username, string password)
        {
            return Users.Where(u => u.UserName.ToUpper().Equals(Username.ToUpper()) && u.Password.Equals(password)).FirstOrDefault();
        }

        public string GenerateToken(string secret, List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
