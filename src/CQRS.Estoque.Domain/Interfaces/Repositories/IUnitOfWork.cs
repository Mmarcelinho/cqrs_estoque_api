namespace CQRS.Estoque.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IRepositoryBase<Categoria> CategoriaRepository { get; }

    IRepositoryBase<Fornecedor> FornecedorRepository { get; }

    IRepositoryBase<Loja> LojaRepository { get; }

    IRepositoryBase<Produto> ProdutoRepository { get; }

    Task CommitAsync();
}
