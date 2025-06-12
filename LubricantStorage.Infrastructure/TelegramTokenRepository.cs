using LubricantStorage.Core.Notifications;

namespace LubricantStorage.Infrastructure
{
    public class TelegramTokenRepository : MongoDbRepositoryBase<string, TelegramToken>, ITelegramTokenRepository
    {
        public TelegramTokenRepository(MongoDbContext context) 
            : base(context) { }
    }
}