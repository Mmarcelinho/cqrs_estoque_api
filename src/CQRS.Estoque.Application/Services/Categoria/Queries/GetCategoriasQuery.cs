namespace CQRS.Estoque.Application.Services.CategoriaQueries;

public class GetCategoriasQuery : IRequest<IEnumerable<Categoria>>
{
    public class GetCategoriasQueryHandler : IRequestHandler<GetCategoriasQuery, IEnumerable<Categoria>>
    {
        private readonly IDapperRepositoryBase<Categoria> _categoriaDapperRepository;

        public GetCategoriasQueryHandler(IDapperRepositoryBase<Categoria> categoriaDapperRepository)
        {
            _categoriaDapperRepository = categoriaDapperRepository;
        }

        public async Task<IEnumerable<Categoria>> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _categoriaDapperRepository.ObterTodosAsync();
            return categorias;
        }
    }

}
