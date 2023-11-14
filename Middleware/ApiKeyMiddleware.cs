namespace ToDoApp.Middleware
{
    public class ApiKeyMiddleware
    {
        const string APIKEY = "NekiApiKey_112233asdf";
        private readonly RequestDelegate next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-Key", out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided");
                return;
            }
            if(!APIKEY.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await next(context);
            
        }
    }
}
