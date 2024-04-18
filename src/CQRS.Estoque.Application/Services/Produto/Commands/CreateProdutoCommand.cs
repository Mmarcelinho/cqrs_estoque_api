namespace CQRS.Estoque.Application.Services.ProdutoCommand;

public class CreateProdutoCommand : ProdutoCommandBase
{
    public class CreateProdutoCommandHandler : IRequestHandler<CreateProdutoCommand, Produto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProdutoCommand> _validator;

        public CreateProdutoCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateProdutoCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Produto> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var newProduto = new Produto(request.Titulo, request.Preco, request.CategoriaId, request.FornecedorId, request.LojaId);

            await _unitOfWork.ProdutoRepository.AdicionarAsync(newProduto);
            await _unitOfWork.CommitAsync();

            return newProduto;
        }
    }

}
