namespace CQRS.Estoque.Data.Tests.Repositories.Dapper;

public class FornecedorDapperRepositoryTests
{
    private readonly DbInMemory _dbInMemory;

    private readonly IDbConnection _connection;

    private readonly FornecedorDapperRepository _fornecedorDapperRepository;

    public FornecedorDapperRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _connection = _dbInMemory.GetConnection();
        _fornecedorDapperRepository = new FornecedorDapperRepository(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var fornecedores = await _fornecedorDapperRepository.ObterTodosAsync();
        fornecedores.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var fornecedor = await _fornecedorDapperRepository.ObterPorIdAsync(id);
        fornecedor.Id.Should().Be(id);
    }

}
