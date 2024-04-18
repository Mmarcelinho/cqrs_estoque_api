namespace CQRS.Estoque.Application.Services.FornecedorCommand;

public class DeleteFornecedorCommand : IRequest
{
    public int Id { get; set; }

    public class DeleteFornecedorCommandHandler : IRequestHandler<DeleteFornecedorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFornecedorCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(DeleteFornecedorCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.FornecedorRepository.RemoverPorIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
        }
    }

}