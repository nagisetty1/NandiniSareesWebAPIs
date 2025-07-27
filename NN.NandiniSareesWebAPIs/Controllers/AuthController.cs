using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using NN.NandiniSarees.Models;
using NN.NandiniSarees.Repositories;
using NN.SareesServices;

namespace NN.NandiniSareesWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsersRepository _usersRepository;
        public AuthController(IAuthService authService, IUsersRepository usersRepository)
        {
            _authService = authService;
            _usersRepository = usersRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            var validatedUser = await _authService.AuthenticateAsync(user.UsernameOrEmail, user.Password);

            //var validatedUser = await _usersRepository.ValidateUserAsync(user.UsernameOrEmail, user.Password);
            if (validatedUser == null) return Unauthorized();

            //TODO: Generate JWT token here and return it
            return Ok(validatedUser);
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            var IsUserAdded = await _usersRepository.AddAsync(user);
            if (IsUserAdded == 0) return Unauthorized();

            //TODO: Generate JWT token here and return it
            return Ok(IsUserAdded);
        }
        //[HttpGet("login/{provider}")]
        //public IActionResult ExternalLogin(string provider, string returnUrl = "/")
        //{
        //    var redirectUrl = Url.Action("ExternalLoginCallback", "Auth", new { ReturnUrl = returnUrl });
        //    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        //    return Challenge(properties, provider);
        //}

        //[HttpGet("externallogincallback")]
        //public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/")
        //{
        //    var authenticateResult = await HttpContext.AuthenticateAsync("Cookies");
        //    if (!authenticateResult.Succeeded)
        //        return Unauthorized();

        //    // Map external user info to your Users table here

        //    return LocalRedirect(returnUrl);
        //}
        //[HttpPost("CustomLogin")]
        //public bool IsCustomLogin([FromBody] User user)
        //{
        //    return string.IsNullOrEmpty(user.AuthProvider) && !string.IsNullOrEmpty(user.PasswordHash);
        //}

        //[HttpPost("ExternalLogin")]
        //public bool IsExternalLogin([FromBody] User user)
        //{
        //    return !string.IsNullOrEmpty(user.AuthProvider) && !string.IsNullOrEmpty(user.ProviderUserId);
        //}
    }
}
