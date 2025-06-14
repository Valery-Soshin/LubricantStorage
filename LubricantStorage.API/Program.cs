using LubricantStorage.API;
using LubricantStorage.Configs;
using LubricantStorage.Infrastructure;
using LubricantStorage.Notifications;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("Authorization"));
builder.Services.Configure<TelegramBotConfig>(builder.Configuration.GetSection("TelegramBot"));
builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("Email"));

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
builder.Services.AddNotificationServices();
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

app.MapNotificationHub();

app.Run();