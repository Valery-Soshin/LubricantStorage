using LubricantStorage.API;
using LubricantStorage.Configs;
using LubricantStorage.Infrastructure;
using LubricantStorage.Notifications;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AuthConfig>(builder.Configuration.GetSection("Authorization"));
builder.Services.Configure<TelegramBotConfig>(builder.Configuration.GetSection("TelegramBot"));
builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("Email"));

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddSignalR();

builder.Services.AddSwaggerGen(c =>
{
    // Основная информация о API
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Настройка JWT-авторизации в Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization", 
        In = ParameterLocation.Header,  
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        Array.Empty<string>()  
    //    }
    //});
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

app.UseHttpLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddTelegramBotWebhooks();

app.UseMiddleware<AuthMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapNotificationHub();

app.Run();