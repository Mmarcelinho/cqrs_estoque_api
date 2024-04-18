namespace CQRS.Estoque.Domain.Interfaces.Repositories;

public interface IDapperRepositoryBase<TEntity> where TEntity : Entity
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
}
