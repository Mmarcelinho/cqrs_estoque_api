namespace CQRS.Estoque.Data.Tests.Repositories.UoW;

public class ProdutoRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public ProdutoRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var produtos = await _unitOfWork.ProdutoRepository.ObterTodosAsync();
        produtos.Should().HaveCount(4);
    }


    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Produto()
    {
        var produto = new Produto(5, "Produto5", 50, 4, 4, 4);
        int objetoId = (int)await _unitOfWork.ProdutoRepository.AdicionarAsync(produto);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);     
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Produto()
    {
        var novoTitulo = "ProdutoUpdated";
        var produto = await _unitOfWork.ProdutoRepository.ObterPorIdAsync(4);

        produto.Atualizar(novoTitulo, produto.Preco, produto.CategoriaId, produto.FornecedorId, produto.LojaId);
        _unitOfWork.ProdutoRepository.AtualizarAsync(produto);
        await _unitOfWork.CommitAsync();

        produto.Titulo.Should().Be(novoTitulo);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Produto()
    {
        var id = 1;
        await _unitOfWork.ProdutoRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var produtoExcluido = await _unitOfWork.ProdutoRepository.ObterPorIdAsync(id);
        produtoExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.ProdutoRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
