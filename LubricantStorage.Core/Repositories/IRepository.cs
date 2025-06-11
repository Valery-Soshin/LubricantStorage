using LubricantStorage.Core.Entities;
using System.Linq.Expressions;

namespace LubricantStorage.Core.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        Task Add(TEntity model);
        Task Update(TEntity model);
        Task Remove(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CheckAny(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CheckAll(Expression<Func<TEntity, bool>> predicate);
    }
}