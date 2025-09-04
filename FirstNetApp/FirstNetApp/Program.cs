var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// "/" => localhost:portnumber
app.MapGet("/", async (HttpContext httpContext) =>
{
    if (httpContext.Request.Method=="GET")
    {
        httpContext.Response.Headers["custom-key"] = "=======application/json =========";
        httpContext.Response.ContentType = "text/html";
        await httpContext.Response.WriteAsync("<h1>this is my response get</h1>");
    }else if (httpContext.Request.Method=="POST")
    {
        await httpContext.Response.WriteAsync("<h1>this is my response POST</h1>");

    }
    //httpContext.Response.StatusCode = 401;
    //await httpContext.Response.WriteAsync("this is my response horization");

});

app.Run();
