namespace LubricantStorage.UI.Web
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey("JwtToken"))
            {
                var token = context.Request.Cookies["JwtToken"];
                context.Request.Headers.Append("Authorization", "Bearer " + token);
            }

            return _next(context);
        }
    }
}