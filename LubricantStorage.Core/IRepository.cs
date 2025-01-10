using System.Linq.Expressions;

namespace LubricantStorage.Core
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        Task Add(TEntity model);
        Task Update(TEntity model);
        Task Remove(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate);
    }
}