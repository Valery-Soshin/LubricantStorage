using LubricantStorage.Core.Entities;

namespace LubricantStorage.Core.Repositories
{
    public interface ITelegramSubscriptionRepository : IRepository<string, TelegramSubscription> { }
}