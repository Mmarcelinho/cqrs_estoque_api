namespace CQRS.Estoque.Application.Services.LojaCommand;

public class LojaCommandBase : IRequest<Loja>
{
    public string Nome { get; set; }

    public string Endereco { get; set; }

    public int Numero { get; set; }

    public string Bairro { get; set; }

    public string Telefone { get; set; }

    public string Cnpj { get; set; }
}
