namespace CQRS.Estoque.Application.Services.LojaQueries;

public class GetLojasQuery : IRequest<IEnumerable<Loja>>
{
    public class GetLojasQueryHandler : IRequestHandler<GetLojasQuery, IEnumerable<Loja>>
    {
        private readonly IDapperRepositoryBase<Loja> _lojasDapperRepository;

        public GetLojasQueryHandler(IDapperRepositoryBase<Loja> lojasDapperRepository)
        {
            _lojasDapperRepository = lojasDapperRepository;
        }

        public async Task<IEnumerable<Loja>> Handle(GetLojasQuery request, CancellationToken cancellationToken)
        {
            var lojas = await _lojasDapperRepository.ObterTodosAsync();
            return lojas;
        }
    }

}
