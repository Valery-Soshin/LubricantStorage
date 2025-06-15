using LubricantStorage.Core.Notifications;

namespace LubricantStorage.Infrastructure.Repositories
{
    public class TelegramTokenRepository : MongoDbRepositoryBase<string, NotificationToken>, INotificationTokenRepository
    {
        public TelegramTokenRepository(MongoDbContext context) 
            : base(context) { }
    }
}