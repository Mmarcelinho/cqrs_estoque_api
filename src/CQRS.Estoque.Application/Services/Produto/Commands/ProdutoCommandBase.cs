namespace CQRS.Estoque.Application.Services.ProdutoCommand;

public class ProdutoCommandBase : IRequest<Produto>
{
    public string Titulo { get; set; }
    
    public decimal Preco { get; set; }

    public int CategoriaId { get; set; }

    public int FornecedorId { get; set; }

    public int LojaId { get; set; }
}
