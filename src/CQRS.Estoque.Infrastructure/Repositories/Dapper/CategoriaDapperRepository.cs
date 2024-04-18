namespace CQRS.Estoque.Infrastructure.Repositories.Dapper;

public class CategoriaDapperRepository : IDapperRepositoryBase<Categoria>
{
    private readonly IDbConnection _dbConnection;

    public CategoriaDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Categoria?> ObterPorIdAsync(int id)
    {
        string query = "SELECT * FROM Categorias WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Categoria>(query, new { Id = id });
    }

    public async Task<IEnumerable<Categoria>> ObterTodosAsync()
    {
        string query = "SELECT * FROM Categorias";
        return await _dbConnection.QueryAsync<Categoria>(query);
    }
}
