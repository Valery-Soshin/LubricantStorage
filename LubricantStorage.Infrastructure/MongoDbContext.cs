using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LubricantStorage.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration["Database:ConnectionString"];

            _database = new MongoClient(connectionString)
                .GetDatabase(configuration["Database:Name"]);
        }

        public IMongoCollection<TModel> GetCollection<TModel>()
        {
            return _database.GetCollection<TModel>(typeof(TModel).Name);
        }
    }
}