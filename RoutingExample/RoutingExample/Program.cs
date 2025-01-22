using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//        // using GetEndpoint

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//    if (endPoint != null)
//    {
        
//        await context.Response.WriteAsync($"Map Endpoint: {endPoint.DisplayName}");
//    }
//    await next(context);
//});


                    // enables routing
app.UseRouting();

// creating end points
//-----------------------------------------------------------------------//
//          // only for Map()

//app.UseEndpoints(endpoints => {
//    //add endpoints
//    endpoints.Map("map1",async (context) => {
//        await context.Response.WriteAsync("In Map1");
//    });

//    endpoints.Map("/map2", async (context) => {
//        await context.Response.WriteAsync("In Map2");
//    });

//});
//----------------------------------------------------------------------//
//                //for MapGET() and MapPost()
//app.UseEndpoints(endpoints =>
//{
//                       //add  your endpoints

//    endpoints.MapGet("map1", async (context) =>
//    {
//        Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//        if (endPoint != null)
//        {
//            await context.Response.WriteAsync($"Map Endpoint: {endPoint.DisplayName} \n");
//        }

//        await context.Response.WriteAsync($"In Map1, path is { context.Request.Path} ");
//    });

//    endpoints.MapPost("/map2", async (context) =>
//    {
//        Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
//        if (endPoint != null)
//        {
//            await context.Response.WriteAsync($"Map Endpoint: {endPoint.DisplayName} \n");
//        }
//        await context.Response.WriteAsync("In Map2");
//    });

//});

//-----------------------------------------------------------------//


                //  using Route Parameters
app.UseEndpoints ( endpoint =>
{
    endpoint.Map("files/{filename}.{extension}", async context =>
    {
        string? filename= Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"in files: {filename} . {extension}");
    });

    endpoint.Map("employee/profile/{empname}", async context =>
    {
        string? empname = Convert.ToString(context.Request.RouteValues["empname"]);
        await context.Response.WriteAsync($"In profile : {empname}");
    });

    // using default value 
    // eg, for prodcut/details/1 
    endpoint.Map("product/details/{id=1}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Product id is : {id}");
    });

});

app.Run(async context =>
{
    await context.Response.WriteAsync($"The request URL is {context.Request.Path}");

});


app.Run();
