namespace LubricantStorage.Core.Notifications
{
    public interface INotificaitonTokenGenerator
    {
        Task<string> GenerateToken(string userId, NotificationType notificationType, CancellationToken cancellationToken);
    }
}