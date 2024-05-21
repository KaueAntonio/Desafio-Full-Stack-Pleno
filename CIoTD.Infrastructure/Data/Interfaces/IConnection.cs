using System.Data.Common;

namespace CIoTD.Infrastructure.Data.Interfaces;

public interface IConnection
{
    DbConnection GetConnection();
}
