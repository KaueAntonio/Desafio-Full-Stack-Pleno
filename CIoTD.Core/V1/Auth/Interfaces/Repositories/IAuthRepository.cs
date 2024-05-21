using CIoTD.Core.V1.Auth.Models;

namespace CIoTD.Core.V1.Auth.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<User> Authenticate(AuthRequest input);
    Task<User> GetUserById(int id);
}
