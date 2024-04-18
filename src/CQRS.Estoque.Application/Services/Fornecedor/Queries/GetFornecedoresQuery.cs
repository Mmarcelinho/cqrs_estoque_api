namespace CQRS.Estoque.Application.Services.FornecedorQueries;

public class GetFornecedoresQuery : IRequest<IEnumerable<Fornecedor>>
{
    public class GetFornecedoresQueryHandler : IRequestHandler<GetFornecedoresQuery, IEnumerable<Fornecedor>>
    {
        private readonly IDapperRepositoryBase<Fornecedor> _fornecedorDapperRepository;

        public GetFornecedoresQueryHandler(IDapperRepositoryBase<Fornecedor> fornecedorDapperRepository)
        {
            _fornecedorDapperRepository = fornecedorDapperRepository;
        }

        public async Task<IEnumerable<Fornecedor>> Handle(GetFornecedoresQuery request, CancellationToken cancellationToken)
        {
            var fornecedores = await _fornecedorDapperRepository.ObterTodosAsync();
            return fornecedores;
        }
    }

}
