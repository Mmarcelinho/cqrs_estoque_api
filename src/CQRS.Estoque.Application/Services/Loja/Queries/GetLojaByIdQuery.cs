namespace CQRS.Estoque.Application.Services.LojaQueries;

public class GetLojaByIdQuery : IRequest<Loja>
{
    public int Id { get; set; }
    public class GetLojaByIdQueryHandler : IRequestHandler<GetLojaByIdQuery, Loja>
    {
        private readonly IDapperRepositoryBase<Loja> _lojaDapperRepository;

        public GetLojaByIdQueryHandler(IDapperRepositoryBase<Loja> lojaDapperRepository)
        {
            _lojaDapperRepository = lojaDapperRepository;
        }

        public async Task<Loja> Handle(GetLojaByIdQuery request, CancellationToken cancellationToken)
        {
            var loja = await _lojaDapperRepository.ObterPorIdAsync(request.Id);
            return loja;
        }
    }

}
