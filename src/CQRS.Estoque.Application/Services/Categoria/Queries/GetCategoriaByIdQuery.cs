namespace CQRS.Estoque.Application.Services.CategoriaQueries;

public class GetCategoriaByIdQuery : IRequest<Categoria>
{
    public int Id { get; set; }
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, Categoria>
    {
        private readonly IDapperRepositoryBase<Categoria> _categoriaDapperRepository;

        public GetCategoriaByIdQueryHandler(IDapperRepositoryBase<Categoria> categoriaDapperRepository)
        {
            _categoriaDapperRepository = categoriaDapperRepository;
        }

        public async Task<Categoria> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaDapperRepository.ObterPorIdAsync(request.Id);
            return categoria;
        }
    }

}
