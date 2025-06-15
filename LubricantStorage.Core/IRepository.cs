using System.Linq.Expressions;

namespace LubricantStorage.Core
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        Task Add(TEntity model, CancellationToken cancellationToken = default);

        Task Update(TEntity model, CancellationToken cancellationToken = default);

        Task Remove(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<IList<TEntity>> List(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

        Task<bool> CheckAny(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}