namespace CQRS.Estoque.Application.Services.FornecedorCommand;

public class CreateFornecedorCommand : FornecedorCommandBase
{
    public class CreateFornecedorCommandHandler : IRequestHandler<CreateFornecedorCommand, Fornecedor>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateFornecedorCommand> _validator;

        public CreateFornecedorCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateFornecedorCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Fornecedor> Handle(CreateFornecedorCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            
            var newFornecedor = new Fornecedor(request.Nome);

            await _unitOfWork.FornecedorRepository.AdicionarAsync(newFornecedor);
            await _unitOfWork.CommitAsync();

            return newFornecedor;
        }
    }

}
