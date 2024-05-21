using CIoTD.Infrastructure.Data.Interfaces;

namespace CIoTD.Core.V1.Devices.Repositories;

public class DevicesRepository(IConnection connection)
{
    private readonly IConnection _connection = connection;

    
}
