using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
// using BuberDinner.Api.MiddleWare; import for the middleware
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{   
    builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
    // builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>()); // Option 2 to create an error handling filter attribute
    builder.Services.AddControllers();

    // Apply custom problem factory

    builder.Services.AddSingleton<ProblemDetailsFactory,BuberDinnerProblemDetailsFactory>();
}

    var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>(); custom implementation registerd here defined in Middeware Option 1 as indicated in the README.md file
    app.UseExceptionHandler("/error"); 
    app.MapControllers();
    app.Run();
}
