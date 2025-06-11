using LubricantStorage.Core.Entities;
using LubricantStorage.Core.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
            await _collection.DeleteManyAsync(predicate);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstAsync();
        }

        public async Task<IEnumerable<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task<bool> CheckAny(Expression<Func<TEntity, bool>> predicate)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            var count = await _collection.CountDocumentsAsync(filter);
            return count > 0;
        }

        public async Task<bool> CheckAll(Expression<Func<TEntity, bool>> predicate)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            long totalCount = await _collection.CountDocumentsAsync(new BsonDocument());
            long matchedCount = await _collection.CountDocumentsAsync(filter);
            return totalCount == matchedCount;
        }
    }
}