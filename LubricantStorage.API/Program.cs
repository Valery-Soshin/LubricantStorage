using LubricantStorage.API.Configs;
using LubricantStorage.API.Extensions;
using LubricantStorage.API.Notifications;
using LubricantStorage.Infrastructure;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("Authorization"));
builder.Services.Configure<TelegramBotConfig>(builder.Configuration.GetSection("TelegramBot"));

builder.Services.AddSignalR();

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter()); 
});

builder.Services.AddApiVersioning(options =>
{
    options.Conventions.Add(new VersionByNamespaceConvention());
});

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});

builder.AddTelegramBotServices();
builder.Services.AddAuthServices(builder.Configuration);
builder.Services.AddBaseServices();
builder.Services.AddMongoDb(builder.Configuration);

builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddHttpLogging();

var app = builder.Build();

app.AddTelegramBotWebhooks();

app.UseHttpLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/notification");

app.Run();