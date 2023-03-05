using Microsoft.AspNetCore.Identity;
using Digital.Models;
using Microsoft.AspNetCore.Mvc;
using Digital.Models.Authentications.Signup;
using System.Drawing;

namespace Digital.Controllers
{
    public class AuthenticationController
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
         {

            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]

        public async Task<ActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            var userExists = await _userManager.FindByEmailAsync(registerUser.Email);
            if(userExists == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response({ Status = "Error", MessagePack = "User already exists" });
            }

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName
            }

            var result = await _userManager.CreateAsync(user);

            if(result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created, new Response({ Status = "Success", Message = "User created Successfully" });

            }
            else
            {
                return StatusCode(StatusCodes.Status501InternalServerError, new Response({ Status = "Error", Message = "User failed to create" });

            }

        }


    }
}
