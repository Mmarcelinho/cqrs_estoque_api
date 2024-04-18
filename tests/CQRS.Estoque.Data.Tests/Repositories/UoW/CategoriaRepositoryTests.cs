namespace CQRS.Estoque.Data.Tests.Repositories.UoW;

public class CategoriaRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public CategoriaRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var categorias = await _unitOfWork.CategoriaRepository.ObterTodosAsync();
        categorias.Should().HaveCount(4);
    }


    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Categoria()
    {
        var categoria = new Categoria(5, "Categoria5");
        int objetoId = (int)await _unitOfWork.CategoriaRepository.AdicionarAsync(categoria);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);     
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Categoria()
    {
        var novoTitulo = "CategoriaUpdated";
        var categoria = await _unitOfWork.CategoriaRepository.ObterPorIdAsync(4);

        categoria.Atualizar(novoTitulo);
        _unitOfWork.CategoriaRepository.AtualizarAsync(categoria);
        await _unitOfWork.CommitAsync();

        categoria.Titulo.Should().Be(novoTitulo);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Categoria()
    {
        var id = 1;
        await _unitOfWork.CategoriaRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var categoriaExcluida = await _unitOfWork.CategoriaRepository.ObterPorIdAsync(id);
        categoriaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.CategoriaRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
