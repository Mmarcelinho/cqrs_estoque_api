namespace CQRS.Estoque.Application.Services.CategoriaCommands.Validations;

    public class CreateCategoriaCommandValidator : AbstractValidator<CreateCategoriaCommand>
    {
        public CreateCategoriaCommandValidator()
        {
            RuleFor(c => c.Titulo)
         .NotEmpty().WithMessage("Titulo inválido. Titulo é obrigátorio")
         .Length(4, 200).WithMessage("O título deve ter entre 3 a 200 caracteres.");
        }
    }
