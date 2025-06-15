namespace LubricantStorage.Core.Notifications
{
    public interface INotificationHandler
    {
        Task SendMessageToAll(string message, CancellationToken cancellationToken = default);

        Task SendMessageToUser(string userId, string message, CancellationToken cancellationToken = default);
    }
}