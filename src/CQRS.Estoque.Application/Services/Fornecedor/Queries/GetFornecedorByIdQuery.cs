namespace CQRS.Estoque.Application.Services.FornecedorQueries;

public class GetFornecedorByIdQuery : IRequest<Fornecedor>
{
    public int Id { get; set; }
    public class GetFornecedorByIdQueryHandler : IRequestHandler<GetFornecedorByIdQuery, Fornecedor>
    {
        private readonly IDapperRepositoryBase<Fornecedor> _fornecedorDapperRepository;

        public GetFornecedorByIdQueryHandler(IDapperRepositoryBase<Fornecedor> fornecedorDapperRepository)
        {
            _fornecedorDapperRepository = fornecedorDapperRepository;
        }

        public async Task<Fornecedor> Handle(GetFornecedorByIdQuery request, CancellationToken cancellationToken)
        {
            var fornecedor = await _fornecedorDapperRepository.ObterPorIdAsync(request.Id);
            return fornecedor;
        }
    }

}
