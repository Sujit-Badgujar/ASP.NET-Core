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

//app.UseRouting();

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
    //file-ext
    endpoints.Map("files/{filename}.{extension}", async context => 
    {
        string? fileName = Convert.ToString(context.Request.RouteValues["filename"]);
        string? ext = Convert.ToString(context.Request.RouteValues["extension"]);

        await context.Response.WriteAsync($"In file- {fileName}-{ext}");
    });

    //Default name
    /*    endpoints.Map("employees/profiles/{empName=Sujit}", async context =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["empName"]);
        await context.Response.WriteAsync($"In Employee Profile - {empName}");
    });*/

    //**** VALIDATIONS ***
    //minlength() & maxlength() contraint in Route/range()/min()/max()

    //endpoints.Map("employees/profiles/{empName:length(3,5):alpha=Sujit}", async context =>

    //endpoints.Map("employees/profiles/{empName:minlength(3):maxlength(5)=Sujit}", async context =>
    endpoints.Map("employees/profiles/{empName:length(3,5)=Sujit}", async context =>
    {
        string? empName = Convert.ToString(context.Request.RouteValues["empName"]);
        await context.Response.WriteAsync($"In Employee Profile name is- {empName}");
    });

    //Default route parameters
    /*    endpoints.Map("product/details/{id=1}", async context =>
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);

            await context.Response.WriteAsync($"Product details- {id}");
        });*/

    //Optional Parameter
    endpoints.Map("product/details/{id?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);

            await context.Response.WriteAsync($"Product details ID is- {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Product details- ID not supplied!");
        }
    });

    //Daily report{reportdate}
    endpoints.Map("daily-report/{ReportDate:datetime}", async context => 
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["ReportDate"]);
        await context.Response.WriteAsync($"In daily-report- date is: {reportDate.ToShortDateString()}");
    });

    //guid : cities/citiID
    endpoints.Map("cities/{citiID:guid}", async context =>
    {
       Guid CityID = Guid.Parse(Convert.ToString(context.Request.RouteValues["citiID"])!);
       
       await context.Response.WriteAsync($"City ID is - {CityID}");  
    });

    //** regex **
    //Sales Report
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(Jan|Feb|Mar|Apr)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);  
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"Sales report date is: {year}-{month}");
    });
    
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Routes didn't match at any endPoints!" +
        $"! : {context.Request.Path}");
});

app.Run();
