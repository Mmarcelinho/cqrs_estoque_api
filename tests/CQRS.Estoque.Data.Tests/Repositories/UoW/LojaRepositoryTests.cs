namespace CQRS.Estoque.Data.Tests.UoW;

public class LojaRepositoryTests
{

    private readonly DbInMemory _DbInMemory;

    private readonly Context _connection;

    private readonly IUnitOfWork _unitOfWork;

    public LojaRepositoryTests()
    {
        _DbInMemory = new DbInMemory();
        _connection = _DbInMemory.GetContext();
        _unitOfWork = new UnitOfWork(_connection);
    }

    [Fact]
    public async Task ObterTodosAsync_Deve_Retornar_Todos_Os_Registros()
    {
        var lojas = await _unitOfWork.LojaRepository.ObterTodosAsync();
        lojas.Should().HaveCount(4);
    }


    [Fact]
    public async Task AdicionarAsync_Deve_Adicionar_E_Retornar_Loja()
    {
        var loja = new Loja(5, "Loja5", "Endereco5", 5, "Bairro5", "71999999999", "123456789101214");
        int objetoId = (int)await _unitOfWork.LojaRepository.AdicionarAsync(loja);
        await _unitOfWork.CommitAsync();
        objetoId.Should().Be(5);     
    }

    [Fact]
    public async Task AtualizarAsync_Deve_Atualizar_Loja()
    {
        var novoNome = "LojaUpdated";
        var loja = await _unitOfWork.LojaRepository.ObterPorIdAsync(4);

        loja.Atualizar(novoNome, loja.Endereco, loja.Numero, loja.Bairro, loja.Telefone, loja.Cnpj);
        _unitOfWork.LojaRepository.AtualizarAsync(loja);
        await _unitOfWork.CommitAsync();

        loja.Nome.Should().Be(novoNome);
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Remover_Loja()
    {
        var id = 1;
        await _unitOfWork.LojaRepository.RemoverPorIdAsync(id);
        await _unitOfWork.CommitAsync();

        var lojaExcluida = await _unitOfWork.LojaRepository.ObterPorIdAsync(id);
        lojaExcluida.Should().BeNull();
    }

    [Fact]
    public async Task RemoverPorIdAsync_Deve_Lancar_Excecao_Para_Registro_Inexistente()
    {
        var id = 100;
        await FluentActions.Invoking(async () => await _unitOfWork.LojaRepository.RemoverPorIdAsync(id)).Should().ThrowAsync<Exception>("O registro não existe na base de dados.");
    }

}
