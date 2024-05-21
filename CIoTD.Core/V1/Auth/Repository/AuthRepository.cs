using System.Data;
using CIoTD.Core.V1.Auth.Interfaces.Repositories;
using CIoTD.Core.V1.Auth.Models;
using CIoTD.Infrastructure.Data.Interfaces;
using Dapper;

namespace CIoTD.Core.V1.Auth.Repositories;

public class AuthRepository(IConnection connection) : IAuthRepository
{
    private readonly IConnection _connection = connection;

    public async Task<User> Authenticate(AuthRequest input)
    {
        using var connection = _connection.GetConnection();

        DynamicParameters parameters = new();
        parameters.Add("@Username", input.Username);
        parameters.Add("@Password", input.Password);

        //var response = await connection.QueryFirstOrDefaultAsync<User>(
        //    sql: @"SELECT Id       = User.Id
        //                 ,Name     = User.Name
        //                 ,Username = User.Username
        //           FROM [dbo].[Users] User
        //           WHERE User.Username = @Username
        //             AND User.Password = @Password",
        //    param: parameters,
        //    commandType: CommandType.Text
        //);
        //
        //return response;

        return new User
        {
            Id = 1,
            Name = "Kaue",
            Password = "123",
            Username = "kaueajs"
        };
    }

    public async Task<User> GetUserById(int id)
    {
        using var connection = _connection.GetConnection();

        DynamicParameters parameters = new();
        parameters.Add("@Id", id);

        var response = await connection.QueryFirstOrDefaultAsync<User>(
            sql: @"SELECT Id       = User.Id
                         ,Name     = User.Name
                         ,Username = User.Username
                   FROM [dbo].[Users] User
                   WHERE User.Id = @Id",
            param: parameters,
            commandType: CommandType.Text
        );

        return response;
    }
}
