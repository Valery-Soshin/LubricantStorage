namespace LubricantStorage.Core.Notifications
{
    public interface INotificationHandler
    {
        Task SendMessageAsync(string message, CancellationToken cancellationToken = default);
    }
}