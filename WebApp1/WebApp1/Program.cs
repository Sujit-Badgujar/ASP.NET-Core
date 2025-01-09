using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//app.MapGet("/", () => "Hello Sujit! How's it going?");

app.Run( async (HttpContext context) =>
{
    //context.Response.StatusCode = 200;

    //context.Response.Headers["Key"]="Value";

    //context.Response.Headers["Server"]="My Server";

    //string path= context.Request.Path;
    //string method = context.Request.Method;

    //context.Response.Headers["Content-Type"] ="Text/Html";

    ////await context.Response.WriteAsync("Hello Sujit, this is test for response headers with key-value pair. you can check in dev tool-> Network tab & click refresh to check values.");

    ////await context.Response.WriteAsync("<h1>This is HTML header test</h1>");

    //await context.Response.WriteAsync($"<p1>{path}</p1>");
    //await context.Response.WriteAsync($"<p1>{method}</p1>");

    //Query String-URL
    /*context.Response.Headers["Content-type"] = "text/html";
    if (context.Request.Method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    }*/

    //Reading request headers
    /*if (context.Request.Query.ContainsKey("id"))
    {
        string id = context.Request.Query["id"];
        await context.Response.WriteAsync($"<p>{id}</p>");
    }*/

    //context.Response.Headers["Content-type"] = "text/html";
    //if (context.Request.Headers.ContainsKey("AuthorizationKey"))
    //{
    //    string auth = context.Request.Headers["AuthorizationKey"];
    //    await context.Response.WriteAsync($"<p>{auth}</p>");
    //}

    StreamReader reader = new StreamReader(context.Request.Body);
    string body= await reader.ReadToEndAsync();


    //StringValues is for multiple values of the key
    Dictionary<string, StringValues> queryDict =
    Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("FirstName")) 
    {
        string firstName = queryDict["FirstName"][0];
        await context.Response.WriteAsync(firstName);

        foreach (var items in queryDict ["FirstName"])
        {
            await context.Response.WriteAsync(items);
        }
    }

    
});

app.Run();
