namespace CQRS.Estoque.Application.Services.FornecedorCommand;

public class FornecedorCommandBase : IRequest<Fornecedor>
{
    public string Nome { get; set; }

    public bool Ativo { get;  set; }
}
