using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CIoTD.Core.V1.Auth.Interfaces.Repositories;
using CIoTD.Core.V1.Auth.Interfaces.Services;
using CIoTD.Core.V1.Auth.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CIoTD.Core.V1.Auth.Services;

public class AuthService(IAuthRepository authRepository, IConfiguration configuration) : IAuthService
{
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly string _settings = configuration.GetSection("Auth").Value;

    public async Task<AuthResponse> Authenticate(AuthRequest input)
    {
        var user = await _authRepository.Authenticate(input)
            ?? throw new Exception("Usuário ou Senha Incorretos!");

        var token = await GenerateToken(user);

        return new AuthResponse(user, token);
    }

    public async Task<User> GetUserById(int id)
    {
        var response = await _authRepository.GetUserById(id);

        return response;
    }

    private async Task<string> GenerateToken(User user)
    {
        var handler = new JwtSecurityTokenHandler();

        var token = await Task.Run(() =>
        {
            var key = Encoding.ASCII.GetBytes(_settings);

            var token = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return handler.CreateToken(token);
        });

        return handler.WriteToken(token);
    }
}
