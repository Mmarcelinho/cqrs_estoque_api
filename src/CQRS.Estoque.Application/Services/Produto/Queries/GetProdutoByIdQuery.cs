namespace CQRS.Estoque.Application.Services.ProdutoQueries;

public class GetProdutoByIdQuery : IRequest<Produto>
{
    public int Id { get; set; }
    public class GetProdutoByIdQueryHandler : IRequestHandler<GetProdutoByIdQuery, Produto>
    {
        private readonly IDapperRepositoryBase<Produto> _produtoDapperRepository;

        public GetProdutoByIdQueryHandler(IDapperRepositoryBase<Produto> produtoDapperRepository)
        {
            _produtoDapperRepository = produtoDapperRepository;
        }

        public async Task<Produto> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _produtoDapperRepository.ObterPorIdAsync(request.Id);
            return produto;
        }
    }

}
