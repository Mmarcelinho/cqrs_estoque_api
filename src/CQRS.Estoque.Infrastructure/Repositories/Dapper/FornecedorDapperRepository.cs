namespace CQRS.Estoque.Infrastructure.Repositories.Dapper;

public class FornecedorDapperRepository : IDapperRepositoryBase<Fornecedor>
{
    private readonly IDbConnection _dbConnection;

    public FornecedorDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Fornecedor?> ObterPorIdAsync(int id)
    {
        string query = "SELECT * FROM Fornecedores WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Fornecedor>(query, new { Id = id });
    }

    public async Task<IEnumerable<Fornecedor>> ObterTodosAsync()
    {
        string query = "SELECT * FROM Fornecedores";
        return await _dbConnection.QueryAsync<Fornecedor>(query);
    }
}
