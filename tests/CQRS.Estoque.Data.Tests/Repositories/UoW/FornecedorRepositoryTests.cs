namespace CQRS.Estoque.Data.Tests.Repositories.UoW;

public class FornecedorRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public FornecedorRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var fornecedores = await _unitOfWork.FornecedorRepository.ObterTodosAsync();
        fornecedores.Should().HaveCount(4);
    }


    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Fornecedor()
    {
        var fornecedor = new Fornecedor(5, "Fornecedor5");
        int objetoId = (int)await _unitOfWork.FornecedorRepository.AdicionarAsync(fornecedor);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);     
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Fornecedor()
    {
        var novoNome = "FornecedorUpdated";
        var fornecedor = await _unitOfWork.FornecedorRepository.ObterPorIdAsync(4);

        fornecedor.Atualizar(novoNome,false);
        _unitOfWork.FornecedorRepository.AtualizarAsync(fornecedor);
        await _unitOfWork.CommitAsync();

        fornecedor.Nome.Should().Be(novoNome);
        fornecedor.Ativo.Should().BeFalse();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Fornecedor()
    {
        var id = 1;
        await _unitOfWork.FornecedorRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var fornecedorExcluido = await _unitOfWork.FornecedorRepository.ObterPorIdAsync(id);
        fornecedorExcluido.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.FornecedorRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
