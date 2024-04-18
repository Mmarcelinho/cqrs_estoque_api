namespace CQRS.Estoque.Application.Services.ProdutoCommand;

public class UpdateProdutoCommand : IRequest
{
    public int Id { get; set; }

    public string Titulo { get; set; }

    public decimal Preco { get; set; }

    public int CategoriaId { get; set; }

    public int FornecedorId { get; set; }

    public int LojaId { get; set; }

    public class UpdateProdutoCommandHandler : IRequestHandler<UpdateProdutoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProdutoCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            var existingProduto = await _unitOfWork.ProdutoRepository.ObterPorIdAsync(request.Id);

            existingProduto.Atualizar(request.Titulo, request.Preco, request.CategoriaId, request.FornecedorId, request.LojaId);

            _unitOfWork.ProdutoRepository.AtualizarAsync(existingProduto);
            await _unitOfWork.CommitAsync();
        }
    }

}