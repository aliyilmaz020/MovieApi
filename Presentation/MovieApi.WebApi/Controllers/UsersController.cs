using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.UserCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.UserQueries;

namespace MovieApi.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRegistrationCommand command)
    {
        var result = await mediator.Send(command);
        if(result is bool)
            return Ok("Kullanıcı kaydı başarılı.");
        else
            return BadRequest(result);
    }
    [HttpGet("check-email-username")]
    public async Task<IActionResult> CheckEmailAndUsername([FromQuery] CheckUserEmailAndUsernameQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand query)
    {
        var result = await mediator.Send(query);
        if(result)
            return Ok("Giriş başarılı.");
        else
            return BadRequest("Kullanıcı adı veya şifre hatalı.");
    }
}
