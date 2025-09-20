using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WepAPICor.net.DTO;
using WepAPICor.net.Models;
using WepAPICor.net.Services;

namespace WepAPICor.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmailService emailService;
        private readonly ITokenService tokenService;

        public AccountController(UserManager<ApplicationUser> userManager, IEmailService emailService, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
            this.tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto UserFromRequset)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = UserFromRequset.UserName,
                Email = UserFromRequset.Email
            };

            var res = await userManager.CreateAsync(user, UserFromRequset.Password);
            if (res.Succeeded)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                    new { userId = user.Id, token = token }, Request.Scheme);

                await emailService.SendEmailAsync(user.Email, "Confirm your email",
                    $"<h1>Welcome!</h1><p>Please confirm your email by clicking <a href='{confirmationLink}'>here</a></p>");

                return Ok("Register Done, Please check your email to confirm your account.");
            }

            foreach (var item in res.Errors)
            {
                ModelState.AddModelError("Password", item.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
                return BadRequest("Invalid Email Confirmation Request");

            var user = await userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return Ok("Email Confirmed Successfully ✅");

            return BadRequest("Email Confirmation Failed ❌");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto UserFromRequset)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userFromDB = await userManager.FindByNameAsync(UserFromRequset.UserName);
            if (userFromDB == null) return BadRequest("User not found");

            if (!await userManager.IsEmailConfirmedAsync(userFromDB))
                return BadRequest("Please confirm your email before logging in.");

            bool found = await userManager.CheckPasswordAsync(userFromDB, UserFromRequset.Password);
            if (!found) return BadRequest("UserName or Password Wrong");

            var roles = await userManager.GetRolesAsync(userFromDB);
            var token = tokenService.CreateToken(userFromDB, roles);

            return Ok(new
            {
                token,
                expiration = DateTime.Now.AddHours(1)
            });
        }
    }
}
