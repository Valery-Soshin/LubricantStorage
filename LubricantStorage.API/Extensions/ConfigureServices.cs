namespace LubricantStorage.API.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            services.AddScoped<NotificationService>();

            return services;
        }
    }
}