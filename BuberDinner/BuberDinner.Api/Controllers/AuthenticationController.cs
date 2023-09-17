using BuberDinner.Api.Filters;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
// Add our ErrorHandlingFilter over here
// [ErrorHandlingFilter] but if we dont want to add it on every controller we can add it inside the application builder
public class AuthenticationController: ControllerBase 
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
         var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token
        );
        return Ok(response);
    }
}