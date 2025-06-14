namespace LubricantStorage.Core.Notifications
{
    public interface INotificaitonTokenGenerator
    {
        Task<string> GenerateAsync(string userId, CancellationToken cancellationToken);
    }
}