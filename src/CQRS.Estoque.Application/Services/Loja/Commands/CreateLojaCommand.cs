namespace CQRS.Estoque.Application.Services.LojaCommand;

public class CreateLojaCommand : LojaCommandBase
{
    public class CreateLojaCommandHandler : IRequestHandler<CreateLojaCommand, Loja>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateLojaCommand> _validator;

        public CreateLojaCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateLojaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Loja> Handle(CreateLojaCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            
            var newLoja = new Loja(request.Nome,request.Endereco,request.Numero,request.Bairro,request.Telefone, request.Cnpj);

            await _unitOfWork.LojaRepository.AdicionarAsync(newLoja);
            await _unitOfWork.CommitAsync();

            return newLoja;
        }
    }

}
