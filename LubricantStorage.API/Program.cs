using LubricantStorage.API.Extensions;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    //.AddHttpClient()
    //.AddHttpContextAccessor()
    //.AddResponseCompression(compressionOptions =>
    //{
    //    compressionOptions.EnableForHttps = true;
    //    compressionOptions.Providers.Add<GzipCompressionProvider>();
    //})
    .AddEndpointsApiExplorer()
    .AddApiVersioning(options =>
    {
        options.Conventions.Add(new VersionByNamespaceConvention());
    });

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();