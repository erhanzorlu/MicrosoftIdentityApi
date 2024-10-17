using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MicrosoftIdentityApi.Dtos;
using MicrosoftIdentityApi.Models;

namespace MicrosoftIdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<AppUser> userManager) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
        {
            AppUser appUser = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            IdentityResult result = await userManager.CreateAsync(appUser, request.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(s => s.Description));
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
        { 
        AppUser appUser=await 
        }
        }
}
