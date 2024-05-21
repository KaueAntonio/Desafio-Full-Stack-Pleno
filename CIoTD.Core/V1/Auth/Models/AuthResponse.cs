namespace CIoTD.Core.V1.Auth.Models;

public class AuthResponse(User user, string token)
{
    public int Id { get; set; } = user.Id;
    public string Name { get; set; } = user.Name;
    public string Username { get; set; } = user.Username;
    public string Token { get; set; } = token;
}
