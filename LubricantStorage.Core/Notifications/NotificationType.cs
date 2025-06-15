namespace LubricantStorage.Core.Notifications
{
    /// <summary>
    /// Тип уведомления 
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Уведомление в системе Lubricant Storage 
        /// </summary>
        System = 0,

        /// <summary>
        /// Уведомление в телеграмме
        /// </summary>
        Telegram = 1,

        /// <summary>
        /// Уведомление по почте
        /// </summary>
        Email = 2
    }
}