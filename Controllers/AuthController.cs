using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rental_system.Interfaces.IServices;
using rental_system.Models.Dtos;
using rental_system.Services;
using System.Security.Claims;

namespace rental_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("/login")]

        public async Task<IActionResult> Login([FromBody] PhoneLoginDto PhoneLoginRequest)
        {
            var response = await _authService.LoginAsync(PhoneLoginRequest);
            
            return HandleResponse(response);
        }


        // Google OAuth

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(GoogleCallback))
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }


        // Google redirects back here after user approves
        [HttpGet("google-callback")]
        public async Task<IActionResult> GoogleCallback()
        {
            var result = await HttpContext.AuthenticateAsync("Cookies");
            if (!result.Succeeded)
                return Unauthorized();

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var name = result.Principal.FindFirstValue(ClaimTypes.Name);
            var googleSubjectId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

            GoogleLoginDto GoogleDetails = new GoogleLoginDto
            {
                Gemail = email,
                Gname = name,
                Gid = googleSubjectId,
            };

            var jwt = await _authService.LoginOrRegisterGoogleUserAsync(GoogleDetails);

            await HttpContext.SignOutAsync("Cookies"); // don't need the temp cookie anymore

            // Redirect to your React app with the JWT (e.g. as a query param or fragment)
            return Redirect($"https://your-frontend.com/oauth-success?token={jwt}");
        }




        [Authorize]
        [HttpPost("me")]
        public async Task<IActionResult> Me()
        {
            var response = await _authService.DecodeTokenAsync();

            return HandleResponse(response);
        }
    }
}
