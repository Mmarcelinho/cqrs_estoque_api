namespace CQRS.Estoque.Application.Services.FornecedorCommands.Validations;

public class CreateFornecedorCommandValidator : AbstractValidator<CreateFornecedorCommand>
{
    public CreateFornecedorCommandValidator()
    {
        RuleFor(c => c.Nome)
     .NotEmpty().WithMessage("Nome inválido. Nome é obrigátorio")
     .Length(4, 200).WithMessage("O nome deve ter entre 3 a 200 caracteres.");
    }
}
