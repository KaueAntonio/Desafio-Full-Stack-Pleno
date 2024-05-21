using CIoTD.Core.V1.Auth.Models;

namespace CIoTD.Core.V1.Auth.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponse> Authenticate(AuthRequest input);
    Task<User> GetUserById(int id);
}
