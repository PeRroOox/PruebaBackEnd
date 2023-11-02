using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using TheLastBugPrueba.IdentityServer;
using TheLastBugPrueba.IdentityServer.Model;
using Microsoft.AspNetCore.Http;

namespace TheLastBugPrueba.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterModel registerDto)
        {
            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            return result;
        }

        public async Task<SignInResult> LoginUserAsync(LoginModel loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
            return result;
        }

        public async Task AuthenticateAsync(HttpContext context, string? scheme)
        {
            // Aquí deberías agregar la lógica para autenticar al usuario
            // Por ejemplo, podría ser algo así:
            var result = await context.AuthenticateAsync(scheme);

            if (!result.Succeeded)
            {
                // Manejar el caso en el que la autenticación falló
            }

            // Si la autenticación fue exitosa, puedes continuar con la lógica que necesites
        }
    }
}
