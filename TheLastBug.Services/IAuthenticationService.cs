using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TheLastBugPrueba.IdentityServer.Model;

namespace TheLastBugPrueba.Services
{
    public interface IAuthenticationService
    {
        Task<SignInResult> LoginUserAsync(LoginModel loginDto);
        Task<IdentityResult> RegisterUserAsync(RegisterModel registerDto);
        Task AuthenticateAsync(HttpContext context, string? scheme);
    }
}
