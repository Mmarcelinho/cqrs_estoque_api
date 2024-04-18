namespace CQRS.Estoque.Data.Tests.Repositories.Dapper;

public class LojaDapperRepositoryTests
{
    private readonly DbInMemory _dbInMemory;

    private readonly IDbConnection _connection;

    private readonly LojaDapperRepository _lojaDapperRepository;

    public LojaDapperRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _connection = _dbInMemory.GetConnection();
        _lojaDapperRepository = new LojaDapperRepository(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var lojas = await _lojaDapperRepository.ObterTodosAsync();
        lojas.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var loja = await _lojaDapperRepository.ObterPorIdAsync(id);
        loja.Id.Should().Be(id);
    }

}
