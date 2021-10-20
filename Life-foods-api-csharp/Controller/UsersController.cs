using Life_foods_api_csharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Life_foods_api_csharp.Controller
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel userParameters)
        {
            var user = _userService.Authenticate(userParameters.Email, userParameters.Password);

            if (user == null)
                return BadRequest(new { message = "Email or Password is incorrect" });

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthenticationModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var existingUser = await _userService.FindByEmailAsync(model.Email);
            //    if (existingUser == null)
            //    {
            //        User user = new User();
            //        user.UserName = model.Email;
            //        user.Email = model.Email;
            //        user.FirstName = model.FirstName;
            //        user.LastName = model.LastName;

            //        IdentityResult result = userManager.CreateAsync(user, model.Password).Result;

            //        if (result.Succeeded)
            //        {
            //            await userManager.AddToRoleAsync(user, "User");
            //            return Created("", model);
            //        }
            //    }

            //}

            return BadRequest();
        }

    }
}
