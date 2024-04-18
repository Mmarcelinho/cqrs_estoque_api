namespace CQRS.Estoque.Domain.Entities;

public class Produto : Entity
{
    public Produto() { }

    public Produto(string titulo, decimal preco, int categoriaId, int fornecedorId, int lojaId)
    {
        DataEntrada = DateTime.Now;
        ValidateDomain(titulo, preco, categoriaId, fornecedorId, lojaId);
    }
    
    [JsonConstructor]
    public Produto(int id, string titulo, decimal preco, int categoriaId, int fornecedorId, int lojaId)
    {
        DomainValidation.When(id < 0, "Valod do Id inválido.");
        Id = id;
        DataEntrada = DateTime.Now;
        ValidateDomain(titulo, preco, categoriaId, fornecedorId, lojaId);
    }

    public void Atualizar(string titulo, decimal preco, int categoriaId, int fornecedorId, int lojaId)
    {
        ValidateDomain(titulo, preco, categoriaId, fornecedorId, lojaId);
    }

    public string Titulo { get; private set; }

    public decimal Preco { get; private set; }

    public DateTime DataEntrada { get; private set; }

    public int CategoriaId { get; private set; }

    public int FornecedorId { get; private set; }

    public int LojaId { get; private set; }

    public Categoria Categoria { get; set; } = null!;

    public Fornecedor Fornecedor { get; set; } = null!;

    public Loja Loja { get; set; } = null!;

    private void ValidateDomain(string titulo, decimal preco, int categoriaId, int fornecedorId, int lojaId)
    {
        DomainValidation.When(string.IsNullOrEmpty(titulo), "Titulo inválido. Titulo é obrigátorio");

        DomainValidation.When(titulo.Length < 3, "Titulo inválido, muito curto, mínimo de 3 caracteres");

        DomainValidation.When(preco <= 0, "Preço inválido.");

        DomainValidation.When(preco <= 0, "Preço é obrigátorio.");

        DomainValidation.When(categoriaId <= 0, "A categoria é obrigátorio.");

        DomainValidation.When(fornecedorId <= 0, "O fornecedor é obrigátorio.");

        DomainValidation.When(lojaId <= 0, "A loja é obrigátorio.");

        Titulo = titulo;
        Preco = preco;
        CategoriaId = categoriaId;
        FornecedorId = fornecedorId;
        LojaId = lojaId;
    }
}