namespace LubricantStorage.UI.Web
{
    public class RedirectUnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _loginPath;

        public RedirectUnauthorizedMiddleware(RequestDelegate next, string loginPath)
        {
            _next = next;
            _loginPath = loginPath;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            // Если ответ 401/403 и это не запрос к API
            if ((context.Response.StatusCode == 401 || context.Response.StatusCode == 403)
                && !context.Request.Path.StartsWithSegments("/api"))
            {
                context.Response.Redirect($"{_loginPath}?returnUrl={context.Request.Path}");
            }
        }
    }
}
