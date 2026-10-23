
using MySqlConnector;

namespace MinorProject4.Data;

public class SupplierRepository
{
    private readonly DbConnectionFactory _factory;

    public SupplierRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Supplier>> GetAllAsync()
    {
        var suppliers = new List<Supplier>();

        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"SELECT SupplierId, SupplierName, Email, Phone
                       FROM Suppliers
                       ORDER BY SupplierId";

        using var command = new MySqlCommand(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            suppliers.Add(new Supplier
            {
                SupplierId = reader.GetInt32("SupplierId"),
                SupplierName = reader.GetString("SupplierName"),
                Email = reader.IsDBNull(reader.GetOrdinal("Email"))
                    ? "" : reader.GetString("Email"),
                Phone = reader.IsDBNull(reader.GetOrdinal("Phone"))
                    ? "" : reader.GetString("Phone")
            });
        }

        return suppliers;
    }

    public async Task AddAsync(Supplier supplier)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"INSERT INTO Suppliers
                       (SupplierName, Email, Phone)
                       VALUES (@name, @email, @phone)";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@name", supplier.SupplierName);
        command.Parameters.AddWithValue("@email", supplier.Email);
        command.Parameters.AddWithValue("@phone", supplier.Phone);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"UPDATE Suppliers
                       SET SupplierName = @name,
                           Email = @email,
                           Phone = @phone
                       WHERE SupplierId = @id";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", supplier.SupplierId);
        command.Parameters.AddWithValue("@name", supplier.SupplierName);
        command.Parameters.AddWithValue("@email", supplier.Email);
        command.Parameters.AddWithValue("@phone", supplier.Phone);

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(int supplierId)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = "DELETE FROM Suppliers WHERE SupplierId = @id";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", supplierId);

        await command.ExecuteNonQueryAsync();
    }
}
