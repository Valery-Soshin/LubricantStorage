using LubricantStorage.API.Extensions;
using LubricantStorage.UI.Web;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("LubricantStorage.API", (httpClinet) =>
{
    httpClinet.BaseAddress = new Uri(builder.Configuration["API:BaseUri"]!);
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddAuthServices(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<AuthMiddleware>();
app.UseMiddleware<RedirectUnauthorizedMiddleware>("/Auth/Login");

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();