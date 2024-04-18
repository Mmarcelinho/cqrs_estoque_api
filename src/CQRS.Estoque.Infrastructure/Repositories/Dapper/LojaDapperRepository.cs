namespace CQRS.Estoque.Infrastructure.Repositories.Dapper;

public class LojaDapperRepository : IDapperRepositoryBase<Loja>
{
    private readonly IDbConnection _dbConnection;

    public LojaDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Loja?> ObterPorIdAsync(int id)
    {
        string query = "SELECT * FROM Lojas WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Loja>(query, new { Id = id });
    }

    public async Task<IEnumerable<Loja>> ObterTodosAsync()
    {
        string query = "SELECT * FROM Lojas";
        return await _dbConnection.QueryAsync<Loja>(query);
    }
}
