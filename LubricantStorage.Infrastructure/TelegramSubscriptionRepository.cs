using LubricantStorage.Core.Entities;
using LubricantStorage.Core.Repositories;

namespace LubricantStorage.Infrastructure
{
    public class TelegramSubscriptionRepository : MongoDbRepositoryBase<string, TelegramSubscription>, ITelegramSubscriptionRepository
    {
        public TelegramSubscriptionRepository(MongoDbContext context)
            : base(context) { }
    }
}