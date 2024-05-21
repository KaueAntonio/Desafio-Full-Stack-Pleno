using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CIoTD.Core.V1.Auth.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace CIoTD.Api.Middlewares;

public class JwtMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private readonly RequestDelegate _next = next;
    private readonly string _settings = configuration.GetSection("Auth").Value;

    public async Task Invoke(HttpContext context, IAuthService authService)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (token is not null)
            await IncludeUser(context, authService, token);

        await _next(context);
    }

    private async Task IncludeUser(HttpContext context, IAuthService authService, string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_settings);

            handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            context.Items["User"] = await authService.GetUserById(userId);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro ao atribuir usuário na sessão", ex);
        }
    }
}
