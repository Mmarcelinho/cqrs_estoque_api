namespace CQRS.Estoque.Domain.Entities;

public class Loja : Entity
{
    public Loja() { }

    public Loja(string nome, string endereco, int numero, string bairro, string telefone, string cnpj)
    {
        ValidateDomain(nome, endereco, numero, bairro, telefone, cnpj);
    }

    [JsonConstructor]
    public Loja(int id, string nome, string endereco, int numero, string bairro, string telefone, string cnpj)
    {
        DomainValidation.When(id < 0, "Valor do Id inválido.");
        Id = id;
        ValidateDomain(nome, endereco, numero, bairro, telefone, cnpj);
    }

    public void Atualizar(string nome, string endereco, int numero, string bairro, string telefone, string cnpj)
    {
        ValidateDomain(nome, endereco, numero, bairro, telefone, cnpj);
    }

    public string Nome { get; private set; }

    public string Endereco { get; private set; }

    public int Numero { get; private set; }

    public string Bairro { get; private set; }

    public string Telefone { get; private set; }

    public string Cnpj { get; private set; }

    public ICollection<Produto> Produtos { get; private set; } = null!;

    private void ValidateDomain(string nome, string endereco, int numero, string bairro, string telefone, string cnpj)
    {
        DomainValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigátorio");

        DomainValidation.When(nome.Length < 3, "Nome inválido, muito curto, mínimo de 3 caracteres");

        DomainValidation.When(string.IsNullOrEmpty(endereco), "Endereço inválido. Endereço é obrigátorio");

        DomainValidation.When(endereco.Length < 5, "Endereço inválido, muito curto, mínimo de 5 caracteres");

        DomainValidation.When(string.IsNullOrEmpty(bairro), "Bairro inválido. Bairro é obrigátorio");

        DomainValidation.When(bairro.Length < 5, "Bairro inválido, muito curto, mínimo de 5 caracteres");

        DomainValidation.When(string.IsNullOrEmpty(telefone), "Telefone inválido. Telefone é obrigátorio");

        DomainValidation.When(telefone.Length < 10, "Telefone inválido.");

        DomainValidation.When(string.IsNullOrEmpty(cnpj), "CNPJ inválido. CNPJ é obrigátorio");

        DomainValidation.When(cnpj.Length < 10, "CNPJ inválido.");

        Nome = nome;
        Endereco = endereco;
        Numero = numero;
        Bairro = bairro;
        Telefone = telefone;
        Cnpj = cnpj;
    }
}