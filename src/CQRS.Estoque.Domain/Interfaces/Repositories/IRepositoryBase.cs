namespace CQRS.Estoque.Domain.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
    Task<object> AdicionarAsync(TEntity objeto);
    void AtualizarAsync(TEntity objeto);
    Task RemoverPorIdAsync(int id);
}
