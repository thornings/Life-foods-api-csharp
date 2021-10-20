using Life_foods_api_csharp.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using Life_foods_api_csharp.Models.Auth;

namespace Life_foods_api_csharp.Services
{
    public class UserService : IUserService
    {
        private readonly JWTSettings _secretSettings;
        private FoodApiContext _context;

        public UserService(IOptions<JWTSettings> secret, FoodApiContext context)
        {
            _secretSettings = secret.Value;
            _context = context;
        }

        //public User GetUserByCredentials(string email, string password)
        //{
        //    return _context.Users.SingleOrDefault(u => u.Email == email && u.PasswordHash == password);
        //}

        //public User FindByEmailAsync(string email)
        //{
        //    return _context.Users.SingleOrDefault(u => u.Email == email);
        //}

        //public User Authenticate(string email, string password)
        //{
        //    var user = GetUserByCredentials(email, password);

        //    // return null if user not found
        //    if (user == null)
        //        return null;

        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_secretSettings.Secret);
        //    var token = tokenHandler.CreateToken(CreateTokenDescriptor(user, key));
        //    user.Token = tokenHandler.WriteToken(token);
        //    user.Password = null;

        //    return user;
        //}

        //private SecurityTokenDescriptor CreateTokenDescriptor(User user, byte[] key)
        //{
        //    return new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //         {
        //            new Claim(ClaimTypes.Name, user.Id.ToString())
        //         }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //}

    }
}
