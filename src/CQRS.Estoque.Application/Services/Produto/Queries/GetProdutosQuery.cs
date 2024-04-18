namespace CQRS.Estoque.Application.Services.ProdutoQueries;

public class GetProdutosQuery : IRequest<IEnumerable<Produto>>
{
    public class GetProdutosQueryHandler : IRequestHandler<GetProdutosQuery, IEnumerable<Produto>>
    {
        private readonly IDapperRepositoryBase<Produto> _produtosDapperRepository;

        public GetProdutosQueryHandler(IDapperRepositoryBase<Produto> produtosDapperRepository)
        {
            _produtosDapperRepository = produtosDapperRepository;
        }

        public async Task<IEnumerable<Produto>> Handle(GetProdutosQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _produtosDapperRepository.ObterTodosAsync();
            return produtos;
        }
    }

}
