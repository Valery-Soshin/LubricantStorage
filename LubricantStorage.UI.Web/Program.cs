using LubricantStorage.UI.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


var key = Encoding.ASCII.GetBytes(builder.Configuration["jwt:SecretKey"]!);
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Äëÿ MVC
        options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme; // Äëÿ SignIn
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Äëÿ ïåðåíàïðàâëåíèé
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["jwt:Issuer"],
            ValidAudience = builder.Configuration["jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });

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