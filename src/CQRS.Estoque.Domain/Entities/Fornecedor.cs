namespace CQRS.Estoque.Domain.Entities;

public class Fornecedor : Entity
{
    public Fornecedor() { }
    public Fornecedor(string nome)
    {
        Ativo = true;
        ValidateDomain(nome);
    }

    [JsonConstructor]
    public Fornecedor(int id, string nome)
    {
        DomainValidation.When(id < 0, "Valod do Id inválido.");
        Id = id;
        Ativo = true;
        ValidateDomain(nome);
    }

    public void Atualizar(string nome, bool ativo)
    {
        Ativo = ativo;
        ValidateDomain(nome);
    }

    public string Nome { get; private set; }

    public bool Ativo { get; private set; }
    public ICollection<Produto> Produtos { get; private set; } = null!;

    private void ValidateDomain(string nome)
    {
        DomainValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigátorio");

        DomainValidation.When(nome.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");

        Nome = nome;
    }
}
