namespace CQRS.Estoque.Data.Tests.Repositories.Dapper;

public class ProdutoDapperRepositoryTests
{
    private readonly DbInMemory _dbInMemory;

    private readonly IDbConnection _connection;

    private readonly ProdutoDapperRepository _produtoDapperRepository;

    public ProdutoDapperRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _connection = _dbInMemory.GetConnection();
        _produtoDapperRepository = new ProdutoDapperRepository(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var produtos = await _produtoDapperRepository.ObterTodosAsync();
        produtos.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var produto = await _produtoDapperRepository.ObterPorIdAsync(id);
        produto.Id.Should().Be(id);
    }

}
