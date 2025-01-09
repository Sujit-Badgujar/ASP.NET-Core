var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Middleware in ASP.NET Core:

//Middleware 1- using lamda expression
app.Use(async (HttpContext context, RequestDelegate next) => {

    await context.Response.WriteAsync("Hello from Middleware-1 &");
    await next(context);
});

//Middleware 2
app.Run(async (HttpContext context) => {

    await context.Response.WriteAsync("Hello from Middleware-2");
});

app.Run();
