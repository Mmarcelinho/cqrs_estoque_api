namespace CQRS.Estoque.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private RepositoryBase<Categoria>? categoriaRepository;

    private RepositoryBase<Fornecedor>? fornecedorRepository;

    private RepositoryBase<Loja>? lojaRepository;

    private RepositoryBase<Produto>? produtoRepository;

    private readonly Context _context;

    public UnitOfWork(Context context)
    {
        _context = context;
    }
    public IRepositoryBase<Categoria> CategoriaRepository
    {
        get
        {
            return categoriaRepository = categoriaRepository ?? new RepositoryBase<Categoria>(_context);
        }
    }

    public IRepositoryBase<Fornecedor> FornecedorRepository
    {
        get
        {
            return fornecedorRepository = fornecedorRepository ?? new RepositoryBase<Fornecedor>(_context);
        }
    }

    public IRepositoryBase<Loja> LojaRepository
    {
        get
        {
            return lojaRepository = lojaRepository ?? new RepositoryBase<Loja>(_context);
        }
    }

    public IRepositoryBase<Produto> ProdutoRepository
    {
        get
        {
            return produtoRepository = produtoRepository ?? new RepositoryBase<Produto>(_context);
        }
    }


    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
