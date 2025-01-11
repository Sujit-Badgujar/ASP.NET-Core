var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

//app.mapGet is shortcut for endpoints.Map
app.MapGet("/", () => "Hello there!"); 

app.Run();
