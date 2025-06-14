namespace LubricantStorage.Core.Notifications
{
    public interface INotificationService
    {
        Task SendMessages(string message, CancellationToken cancellationToken = default);
    }
}