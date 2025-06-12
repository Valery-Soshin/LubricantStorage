using LubricantStorage.Core.Notifications;

namespace LubricantStorage.Infrastructure
{
    public class TelegramSubscriptionRepository : MongoDbRepositoryBase<string, TelegramSubscription>, ITelegramSubscriptionRepository
    {
        public TelegramSubscriptionRepository(MongoDbContext context)
            : base(context) { }
    }
}