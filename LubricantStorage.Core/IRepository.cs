using System.Linq.Expressions;

namespace LubricantStorage.Core
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task Add(TEntity model);
        Task Remove(TEntity model);
        Task Update(TEntity model);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate);
    }
}