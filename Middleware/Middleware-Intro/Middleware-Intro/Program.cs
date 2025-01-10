using Middleware_Intro.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();

//Middleware in ASP.NET Core: using lamda expression

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) => {

    await context.Response.WriteAsync("Hello from Middleware-1 &\n");
    await next(context);
});

//app.Use(async (HttpContext context, RequestDelegate next) => {
/*app.Use(async (context, next) => {

    await context.Response.WriteAsync("Hello from Middleware-1 &");
    await next(context); //This is optional only necessary for calling 3rd middleware
});*/

//Middleware 2
//app.UseMiddleware<MyCustomMiddleware>();

app.UseMyCustomMiddleware();

//Middleware 3
app.Run(async (HttpContext context) => {

    await context.Response.WriteAsync("Hello from Middleware-3\n");
});

app.Run();
