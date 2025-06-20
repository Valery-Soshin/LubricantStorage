﻿namespace LubricantStorage.Core.Notifications
{
    public interface INotificaitonTokenGenerator
    {
        Task<NotificationToken> GenerateToken(string userId, NotificationType notificationType, CancellationToken cancellationToken);
    }
}