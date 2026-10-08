using Auth.Model;

namespace Auth.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(Register register);
        Task<AuthResponse> LoginAsync(Login login);
        Task LogoutAsync();
    }
}
