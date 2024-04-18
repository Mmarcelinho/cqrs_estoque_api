namespace CQRS.Estoque.Data.Tests.Repositories.Dapper;

public class CategoriaDapperRepositoryTests
{
    private readonly DbInMemory _dbInMemory;

    private readonly IDbConnection _connection;

    private readonly CategoriaDapperRepository _categoriaDapperRepository;

    public CategoriaDapperRepositoryTests()
    {
        _dbInMemory = new DbInMemory();
        _connection = _dbInMemory.GetConnection();
        _categoriaDapperRepository = new CategoriaDapperRepository(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var categorias = await _categoriaDapperRepository.ObterTodosAsync();
        categorias.Should().HaveCount(4);
    }

    [Fact]
    public async Task ObterPorIdAsync_Deve_Retornar_Registro_Com_O_Id_Especificado()
    {
        var id = 4;
        var categoria = await _categoriaDapperRepository.ObterPorIdAsync(id);
        categoria.Id.Should().Be(id);
    }

}
