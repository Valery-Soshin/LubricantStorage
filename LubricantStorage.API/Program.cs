using LubricantStorage.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHttpLogging();

//builder.Services.AddHttpClient();
//builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.Conventions.Add(new VersionByNamespaceConvention());
});

builder.Services.AddResponseCompression(compressionOptions =>
{
    compressionOptions.EnableForHttps = true;
    compressionOptions.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddMongoDb();

var app = builder.Build();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();