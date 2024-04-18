namespace CQRS.Estoque.Application.Services.CategoriaCommand;

public class DeleteCategoriaCommand : IRequest
{
    public int Id { get; set; }

    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoriaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
           await _unitOfWork.CategoriaRepository.RemoverPorIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
        }
    }

}