
using MySqlConnector;

namespace MinorProject4.Data;

public class ProductRepository
{
    private readonly DbConnectionFactory _factory;

    public ProductRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var products = new List<Product>();

        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"SELECT ProductId, ProductName, Brand,
                              Price, Quantity, CategoryId, SupplierId
                       FROM Products
                       ORDER BY ProductId";

        using var command = new MySqlCommand(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            products.Add(new Product
            {
                ProductId = reader.GetInt32("ProductId"),
                ProductName = reader.GetString("ProductName"),
                Brand = reader.IsDBNull(reader.GetOrdinal("Brand"))
                    ? "" : reader.GetString("Brand"),
                Price = reader.GetDecimal("Price"),
                Quantity = reader.GetInt32("Quantity"),
                CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId"))
                    ? 0 : reader.GetInt32("CategoryId"),
                SupplierId = reader.IsDBNull(reader.GetOrdinal("SupplierId"))
                    ? 0 : reader.GetInt32("SupplierId")
            });
        }

        return products;
    }


public async Task AddAsync(Product product)
{
    using var connection = _factory.CreateConnection();
    await connection.OpenAsync();

    string sql = @"INSERT INTO Products
                   (ProductName, Brand, Price, Quantity,
                    CategoryId, SupplierId)
                   VALUES
                   (@name, @brand, @price, @quantity,
                    @categoryId, @supplierId)";

    using var command = new MySqlCommand(sql, connection);

    command.Parameters.AddWithValue("@name", product.ProductName);
    command.Parameters.AddWithValue("@brand", product.Brand);
    command.Parameters.AddWithValue("@price", product.Price);
    command.Parameters.AddWithValue("@quantity", product.Quantity);
    command.Parameters.AddWithValue("@categoryId", product.CategoryId);
    command.Parameters.AddWithValue("@supplierId", product.SupplierId);

    await command.ExecuteNonQueryAsync();
}


public async Task UpdateAsync(Product product)
{
    using var connection = _factory.CreateConnection();
    await connection.OpenAsync();

    string sql = @"UPDATE Products
                   SET ProductName = @name,
                       Brand = @brand,
                       Price = @price,
                       Quantity = @quantity,
                       CategoryId = @categoryId,
                       SupplierId = @supplierId
                   WHERE ProductId = @id";

    using var command = new MySqlCommand(sql, connection);

    command.Parameters.AddWithValue("@id", product.ProductId);
    command.Parameters.AddWithValue("@name", product.ProductName);
    command.Parameters.AddWithValue("@brand", product.Brand);
    command.Parameters.AddWithValue("@price", product.Price);
    command.Parameters.AddWithValue("@quantity", product.Quantity);
    command.Parameters.AddWithValue("@categoryId", product.CategoryId);
    command.Parameters.AddWithValue("@supplierId", product.SupplierId);

    await command.ExecuteNonQueryAsync();
}

public async Task DeleteAsync(int productId)
{
    using var connection = _factory.CreateConnection();
    await connection.OpenAsync();

    string sql = "DELETE FROM Products WHERE ProductId = @id";

    using var command = new MySqlCommand(sql, connection);
    command.Parameters.AddWithValue("@id", productId);

    await command.ExecuteNonQueryAsync();
}

public async Task<List<Product>> SearchAsync(string name, string brand)
{
    var products = new List<Product>();

    using var connection = _factory.CreateConnection();
    await connection.OpenAsync();

    string sql = @"SELECT ProductId, ProductName, Brand,
                          Price, Quantity, CategoryId, SupplierId
                   FROM Products
                   WHERE ProductName LIKE @name
                     AND Brand LIKE @brand
                   ORDER BY ProductId";

    using var command = new MySqlCommand(sql, connection);

    command.Parameters.AddWithValue("@name", "%" + name + "%");
    command.Parameters.AddWithValue("@brand", "%" + brand + "%");

    using var reader = await command.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        products.Add(new Product
        {
            ProductId = reader.GetInt32("ProductId"),
            ProductName = reader.GetString("ProductName"),
            Brand = reader.IsDBNull(reader.GetOrdinal("Brand"))
                ? "" : reader.GetString("Brand"),
            Price = reader.GetDecimal("Price"),
            Quantity = reader.GetInt32("Quantity"),
            CategoryId = reader.IsDBNull(reader.GetOrdinal("CategoryId"))
                ? 0 : reader.GetInt32("CategoryId"),
            SupplierId = reader.IsDBNull(reader.GetOrdinal("SupplierId"))
                ? 0 : reader.GetInt32("SupplierId")
        });
    }

    return products;
}

}
