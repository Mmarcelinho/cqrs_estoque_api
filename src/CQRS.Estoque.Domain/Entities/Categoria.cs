namespace CQRS.Estoque.Domain.Entities;

public class Categoria : Entity
{
    public Categoria() { }
    public Categoria(string titulo)
    {
        ValidateDomain(titulo);
    }
    
    [JsonConstructor]
    public Categoria(int id, string titulo)
    {
        DomainValidation.When(id < 0, "Valod do Id inválido.");
        Id = id;
        ValidateDomain(titulo);
    }

    public void Atualizar(string titulo)
    {
        ValidateDomain(titulo);
    }

    public string Titulo { get; private set; }

    public ICollection<Produto>? Produtos { get; private set; }

    private void ValidateDomain(string titulo)
    {
        DomainValidation.When(string.IsNullOrEmpty(titulo), "Titulo inválido. Titulo é obrigátorio");

        DomainValidation.When(titulo.Length < 3, "Titulo inválido, muito curto, mínimo de 3 caracteres");

        Titulo = titulo;
    }

}