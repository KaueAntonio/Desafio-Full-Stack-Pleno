using System.Data.Common;
using CIoTD.Infrastructure.Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CIoTD.Infrastructure.Data;

public class Connection(IConfiguration configuration) : IConnection
{
    private readonly IConfiguration _configuration = configuration;

    public DbConnection GetConnection()
    {
        string connectionString = _configuration.GetSection("ConnectionString").Value
            ?? throw new Exception("String de Conexão Não Configurada!");
        
        return new SqlConnection(connectionString);
    }
}
