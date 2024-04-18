namespace CQRS.Estoque.Application.Services.CategoriaCommand;

public class CreateCategoriaCommand : CategoriaCommandBase
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, Categoria>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateCategoriaCommand> _validator;

        public CreateCategoriaCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateCategoriaCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Categoria> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var newCategoria = new Categoria(request.Titulo);

            await _unitOfWork.CategoriaRepository.AdicionarAsync(newCategoria);
            await _unitOfWork.CommitAsync();

            return newCategoria;
        }
    }

}
