var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//
/*app.Use(async ( context,  next) => 
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint == null)
    {
        await context.Response.WriteAsync("No endpoint matched this request.\n");
    }
    else
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
    }

    await next(context);
});*/


/*app.Use(async ( context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint == null)
    {
        await context.Response.WriteAsync("No endpoint matched this request.\n");
    }
    else
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");
    }

    await next(context);
});*/

//creating end points
/*app.UseEndpoints(endpoints =>
{
    //endpoint
    endpoints.MapGet("/map1", async (context) =>
    {
        await context.Response.WriteAsync("In Map-1");
    });

    //Endpoint
    endpoints.MapPost("/map2", async (context) =>
    {
        await context.Response.WriteAsync("In Map-2");
    });
});*/

//enabling routing
app.UseRouting();

//***   Routing parameters ***
app.UseEndpoints(endpoints =>
{
    //
    endpoints.Map("files/{filename}.{extension}", async context => 
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? ext = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In file- {fileName}-{ext}");
    });

    //
    endpoints.Map("employees/profiles/{empName=Sujit}", async context =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["empName"]);
        await context.Response.WriteAsync($"In Employee Profile - {empName}");
    });

    //Default route parameters
    endpoints.Map("product/details/{id=1}", async context =>
    {
        int id= Convert.ToInt32(context.Request.RouteValues["id"]);

        await context.Response.WriteAsync($"Product details- {id}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
