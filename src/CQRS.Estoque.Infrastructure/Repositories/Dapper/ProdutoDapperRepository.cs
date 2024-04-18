namespace CQRS.Estoque.Infrastructure.Repositories.Dapper;

public class ProdutoDapperRepository : IDapperRepositoryBase<Produto>
{
    private readonly IDbConnection _dbConnection;

    public ProdutoDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Produto?> ObterPorIdAsync(int id)
    {
        string query = "SELECT * FROM Produtos WHERE Id = @Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Produto>(query, new { Id = id });
    }

  public async Task<IEnumerable<Produto>> ObterTodosAsync()
{
    string query = @"
        SELECT * FROM Produtos 
        INNER JOIN Categorias ON Produtos.CategoriaId = Categorias.Id
        INNER JOIN Fornecedores ON Produtos.FornecedorId = Fornecedores.Id
        INNER JOIN Lojas ON Produtos.LojaId = Lojas.Id";
    
    var produtos = await _dbConnection.QueryAsync<Produto, Categoria, Fornecedor, Loja, Produto>(
        query,
        map: (produto, categoria, fornecedor, loja) =>
        {
            produto.Categoria = categoria;
            produto.Fornecedor = fornecedor;
            produto.Loja = loja;
            return produto;
        },
        splitOn: "Id, Id, Id");
    
    return produtos;
}
}
