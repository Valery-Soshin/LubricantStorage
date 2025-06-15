using LubricantStorage.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq.Expressions;

namespace LubricantStorage.Infrastructure.Repositories
{
    public class MongoDbRepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : IEntity<TKey>
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoDbRepositoryBase(MongoDbContext context)
        {
            _collection = context.GetCollection<TEntity>();
        }

        public async Task Add(TEntity model, CancellationToken cancellationToken = default)
        {
            await _collection.InsertOneAsync(model, cancellationToken: cancellationToken);
        }

        public async Task Update(TEntity model, CancellationToken cancellationToken = default)
        {
            await _collection.FindOneAndReplaceAsync(m => m.Id.Equals(model.Id), model, cancellationToken: cancellationToken);
        }

        public async Task Remove(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            await _collection.DeleteManyAsync(predicate, cancellationToken);
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<IList<TEntity>> List(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _collection.Find(predicate).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<bool> CheckAny(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Where(predicate);
            var count = await _collection.CountDocumentsAsync(filter, cancellationToken: cancellationToken);
            return count > 0;
        }
    }
}