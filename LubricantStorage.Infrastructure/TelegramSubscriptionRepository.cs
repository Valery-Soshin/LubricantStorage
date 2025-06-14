using LubricantStorage.Core.Notifications;

namespace LubricantStorage.Infrastructure
{
    public class TelegramSubscriptionRepository : MongoDbRepositoryBase<string, NotificationSubscription>, INotificationSubscriptionRepository
    {
        public TelegramSubscriptionRepository(MongoDbContext context)
            : base(context) { }
    }
}