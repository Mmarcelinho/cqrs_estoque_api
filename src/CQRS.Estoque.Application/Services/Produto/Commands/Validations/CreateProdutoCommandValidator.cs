namespace CQRS.Estoque.Application.Services.ProdutoCommands.Validations;

public class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    public CreateProdutoCommandValidator()
    {
        RuleFor(c => c.Titulo)
     .NotEmpty().WithMessage("Título inválido. Título é obrigátorio")
     .Length(3, 200).WithMessage("O titulo deve ter entre 3 a 50 caracteres.");

        RuleFor(c => c.Preco)
               .NotNull().WithMessage("O preço é obrigatório.")
               .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");

        RuleFor(c => c.CategoriaId)
                    .NotNull().WithMessage("A categoriaId é obrigatório.")
                    .GreaterThan(0).WithMessage("A categoriaId deve ser maior que zero.");

        RuleFor(c => c.FornecedorId)
        .NotNull().WithMessage("O FornecedorId é obrigatório.")
        .GreaterThan(0).WithMessage("O FornecedorId deve ser maior que zero.");

        RuleFor(c => c.LojaId)
        .NotNull().WithMessage("A LojaId é obrigatório.")
        .GreaterThan(0).WithMessage("A LojaId deve ser maior que zero.");
    }
}
