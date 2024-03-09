using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tasks.Data;
using Tasks.Interfaces;
using Tasks.Models;

namespace Tasks.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("secret");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetUser(int Id)
        {
            return _context.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public string LoginUser(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.email == user.email && u.passwordHash == user.passwordHash);

            if (existingUser != null)
            {
                return GenerateJwtToken(existingUser);
            }

            return null;
        }

        public bool RegisterUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExists(int Id)
        {
            return _context.Users.Any(r => r.Id == Id);
        }
    }
}
