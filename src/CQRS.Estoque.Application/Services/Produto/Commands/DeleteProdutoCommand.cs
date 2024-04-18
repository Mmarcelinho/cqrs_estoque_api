namespace CQRS.Estoque.Application.Services.ProdutoCommand;

public class DeleteProdutoCommand : IRequest
{
    public int Id { get; set; }

    public class DeleteProdutoCommandHandler : IRequestHandler<DeleteProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProdutoCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(DeleteProdutoCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProdutoRepository.RemoverPorIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
        }
    }

}