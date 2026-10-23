
using MySqlConnector;

namespace MinorProject4.Data;

public class CategoryRepository
{
    private readonly DbConnectionFactory _factory;

    public CategoryRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        var categories = new List<Category>();

        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"SELECT CategoryId, CategoryName, Description
                       FROM Categories
                       ORDER BY CategoryId";

        using var command = new MySqlCommand(sql, connection);
        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            categories.Add(new Category
            {
                CategoryId = reader.GetInt32("CategoryId"),
                CategoryName = reader.GetString("CategoryName"),
                Description = reader.IsDBNull(reader.GetOrdinal("Description"))
                    ? "" : reader.GetString("Description")
            });
        }

        return categories;
    }

    public async Task AddAsync(Category category)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"INSERT INTO Categories
                       (CategoryName, Description)
                       VALUES (@name, @description)";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@name", category.CategoryName);
        command.Parameters.AddWithValue("@description", category.Description);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = @"UPDATE Categories
                       SET CategoryName = @name,
                           Description = @description
                       WHERE CategoryId = @id";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", category.CategoryId);
        command.Parameters.AddWithValue("@name", category.CategoryName);
        command.Parameters.AddWithValue("@description", category.Description);

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(int categoryId)
    {
        using var connection = _factory.CreateConnection();
        await connection.OpenAsync();

        string sql = "DELETE FROM Categories WHERE CategoryId = @id";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.AddWithValue("@id", categoryId);

        await command.ExecuteNonQueryAsync();
    }
}
