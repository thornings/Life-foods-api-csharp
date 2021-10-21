using Life_foods_api_csharp.Models.V1.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Life_foods_api_csharp.Controller
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserManager<User> _userManager;
        private readonly IConfiguration _configuration;


        public UsersController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(AuthenticationModel authModel)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == authModel.Email);
            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, authModel.Password);

            if (userSigninResult)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = BuildAuthClaims(user, userRoles);

                JwtSecurityToken token = BuildJWTToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return BadRequest(new { message = "Email or Password incorrect" });

            
        }

        private List<Claim> BuildAuthClaims(User user, IList<string> userRoles)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }

        private JwtSecurityToken BuildJWTToken(List<Claim> authClaims)
        {
            var appSecretSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSecretSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Secret));

            var token = new JwtSecurityToken(
                issuer: appSettings.ValidIssuer,
                audience: appSettings.ValidAudience,
                expires: DateTime.Now.AddHours(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return Conflict(new { message = $"An existing record with the email '{model.Email}' was already found." });

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "User creation failed! Please check user details and try again." );
            }
            
            return Ok(user);
        }

    }
}
