namespace CQRS.Estoque.Application.Services.FornecedorCommand;

public class UpdateFornecedorCommand : IRequest
{
    public int Id { get; set; }

    public string Nome { get; set; }  

    public bool Ativo { get; set; }
    
    public class UpdateFornecedorCommandHandler : IRequestHandler<UpdateFornecedorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFornecedorCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(UpdateFornecedorCommand request, CancellationToken cancellationToken)
        {
            var existingFornecedor = await _unitOfWork.FornecedorRepository.ObterPorIdAsync(request.Id);


            existingFornecedor.Atualizar(request.Nome,request.Ativo);

            _unitOfWork.FornecedorRepository.AtualizarAsync(existingFornecedor);
            await _unitOfWork.CommitAsync();
        }
    }

}