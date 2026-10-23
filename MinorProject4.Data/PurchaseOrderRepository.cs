
using MySqlConnector;

namespace MinorProject4.Data;

public class PurchaseOrderRepository
{
    private readonly DbConnectionFactory _factory;

    public PurchaseOrderRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<PurchaseOrder>> GetAllAsync()
    {
        var orders = new List<PurchaseOrder>();

        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"SELECT OrderId, SupplierId, OrderDate, Status
                       FROM PurchaseOrders
                       ORDER BY OrderId";

        using var command = new MySqlCommand(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            orders.Add(new PurchaseOrder
            {
                OrderId = reader.GetInt32("OrderId"),
                SupplierId = reader.GetInt32("SupplierId"),
                OrderDate = reader.GetDateTime("OrderDate"),
                Status = reader.IsDBNull(reader.GetOrdinal("Status"))
                    ? "" : reader.GetString("Status")
            });
        }

        return orders;
    }

    public async Task UpdateStatusAsync(int orderId, string status)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"UPDATE PurchaseOrders
                       SET Status = @status
                       WHERE OrderId = @id";

        using var command = new MySqlCommand(sql, connection);

        command.Parameters.AddWithValue("@id", orderId);
        command.Parameters.AddWithValue("@status", status);

        await command.ExecuteNonQueryAsync();
    }
}
