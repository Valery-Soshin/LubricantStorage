namespace LubricantStorage.Core.Notifications
{
    public interface INotificationService
    {
        Task SendMessageAsync(string message, CancellationToken cancellationToken = default);
    }
}