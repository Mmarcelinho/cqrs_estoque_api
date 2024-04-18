namespace CQRS.Estoque.Application.Services.CategoriaCommand;

public class UpdateCategoriaCommand : IRequest
{
    public int Id { get; set; }
    
    public string Titulo { get; set; }
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoriaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        public async Task Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var existingCategoria = await _unitOfWork.CategoriaRepository.ObterPorIdAsync(request.Id);

            existingCategoria.Atualizar(request.Titulo);

            _unitOfWork.CategoriaRepository.AtualizarAsync(existingCategoria);
            await _unitOfWork.CommitAsync();
        }
    }

}