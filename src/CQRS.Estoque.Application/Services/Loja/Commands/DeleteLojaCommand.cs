namespace CQRS.Estoque.Application.Services.LojaCommand;

public class DeleteLojaCommand : IRequest
{
    public int Id { get; set; }

    public class DeleteLojaCommandHandler : IRequestHandler<DeleteLojaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLojaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(DeleteLojaCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.LojaRepository.RemoverPorIdAsync(request.Id);
            await _unitOfWork.CommitAsync();
        }
    }

}