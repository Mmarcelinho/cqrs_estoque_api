namespace CQRS.Estoque.Application.Services.LojaCommands.Validations;

public class CreateLojaCommandValidator : AbstractValidator<CreateLojaCommand>
{
    public CreateLojaCommandValidator()
    {
        RuleFor(c => c.Nome)
     .NotEmpty().WithMessage("Nome inválido. Nome é obrigátorio")
     .Length(4, 50).WithMessage("O nome deve ter entre 3 a 50 caracteres.");

      RuleFor(c => c.Endereco)
     .NotEmpty().WithMessage("Endereço inválido. Endereço é obrigátorio")
     .Length(5, 50).WithMessage("O endereço deve ter entre 5 a 50 caracteres.");

     RuleFor(c => c.Bairro)
     .NotEmpty().WithMessage("Bairro inválido. Bairro é obrigátorio")
     .Length(5, 50).WithMessage("O bairro deve ter entre 5 a 50 caracteres.");

     RuleFor(c => c.Telefone)
     .NotEmpty().WithMessage("Telefone inválido. Telefone é obrigátorio")
     .Length(10, 14).WithMessage("O telefone deve ter entre 10 a 14 Digitos.");

     RuleFor(c => c.Cnpj)
     .NotEmpty().WithMessage("CNPJ inválido. CNPJ é obrigátorio")
     .Length(10, 18).WithMessage("O CNPJ deve ter entre 10 a 18 Digitos.");
    }
}
