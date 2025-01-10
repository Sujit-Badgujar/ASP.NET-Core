
namespace Middleware_Intro.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("CustomMiddleware-1\n");

            await next(context);

            await context.Response.WriteAsync("CustomMiddleware-2\n");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<MyCustomMiddleware>();
            
        }
    }
}
