using Microsoft.AspNetCore.Mvc;
using TheLastBugPrueba.IdentityServer.Model;
using TheLastBugPrueba.Services;

namespace TheLastBugPrueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _authenticationService.RegisterUserAsync(registerModel);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authenticationService.LoginUserAsync(loginModel);

            if (result.Succeeded)
            {
                // Aquí podrías generar un token de acceso y devolverlo al cliente.
                return Ok();
            }

            if (result.IsLockedOut)
            {
                return BadRequest("User account locked.");
            }

            return BadRequest("Invalid login attempt.");
        }
    }
}
