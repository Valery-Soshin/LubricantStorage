using LubricantStorage.Core.Lubricants;

namespace LubricantStorage.Infrastructure.Repositories
{
    public class LubricantRepository : MongoDbRepositoryBase<string, Lubricant>, ILubricantRepository
    {
        public LubricantRepository(MongoDbContext context)
            : base(context) { }
    }
}