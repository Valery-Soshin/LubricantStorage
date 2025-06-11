using LubricantStorage.Core.Entities;
using LubricantStorage.Core.Repositories;

namespace LubricantStorage.Infrastructure
{
    public class LubricantRepository : MongoDbRepositoryBase<string, Lubricant>, ILubricantRepository
    {
        public LubricantRepository(MongoDbContext context)
            : base(context) { }
    }
}