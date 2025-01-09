var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Middleware using lamda expression
app.Run(async (HttpContext context) => {

    await context.Response.WriteAsync("Hello from Middleware.");
});

app.Run();
