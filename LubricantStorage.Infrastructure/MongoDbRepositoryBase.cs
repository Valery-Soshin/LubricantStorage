using LubricantStorage.Core;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LubricantStorage.Infrastructure
{
    public class MongoDbRepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoDbRepositoryBase(MongoDbContext context)
        {
            _collection = context.GetCollection<TEntity>();
        }

        public async Task Add(TEntity model)
        {
            await _collection.InsertOneAsync(model);
        }

        public async Task Update(TEntity model)
        {
            await _collection.FindOneAndReplaceAsync(m => m.Id.Equals(model.Id), model);
        }

        public async Task Remove(Expression<Func<TEntity, bool>> predicate)
        {
            await _collection.DeleteOneAsync(predicate);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstAsync();
        }

        public async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }
    }
}