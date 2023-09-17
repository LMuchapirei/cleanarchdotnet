using BuberDinner.Api.Filters;
// using BuberDinner.Api.MiddleWare; import for the middleware
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{   
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>()); // Option 2 to create an error handling filter attribute
}

    var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>(); custom implementation registerd here defined in Middeware Option 1 as indicated in the README.md file
    app.MapControllers();
    app.Run();
}
