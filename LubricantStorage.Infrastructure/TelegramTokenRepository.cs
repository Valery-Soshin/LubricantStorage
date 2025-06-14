using LubricantStorage.Core.Notifications;

namespace LubricantStorage.Infrastructure
{
    public class TelegramTokenRepository : MongoDbRepositoryBase<string, NotificationToken>, INotificationTokenRepository
    {
        public TelegramTokenRepository(MongoDbContext context) 
            : base(context) { }
    }
}