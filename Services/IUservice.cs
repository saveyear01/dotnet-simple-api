using AuthApi.Models.DTOs;

namespace AuthApi.Services
{
    public interface IUserService
    {
        AuthResponse Register(RegisterRequest request);
        AuthResponse Login(LoginRequest request);
    }
}
