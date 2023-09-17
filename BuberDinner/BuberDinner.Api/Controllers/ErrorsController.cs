using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;


 [Route("/error")]
public class ErrorsController: ControllerBase {
    
    public IActionResult Error()
    {
        Exception? exception  = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode,message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict,"Email already exists."),
            _=> (StatusCodes.Status500InternalServerError,"An unexpected error occurred")
        };
        return Problem(statusCode:statusCode,title:message);
    }
}