var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello Sujit! How's it going?");

app.Run( async (HttpContext context) =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync(" there!");


});

app.Run();
