using LubricantStorage.Core;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace LubricantStorage.Infrastructure
{
    public class MongoDbRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : IEntity
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

        public async Task Remove(TEntity model)
        {
            await _collection.DeleteOneAsync(m => m.Id == model.Id);
        }

        public async Task Update(TEntity model)
        {
            await _collection.FindOneAndReplaceAsync(m => m.Id == model.Id, model);
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