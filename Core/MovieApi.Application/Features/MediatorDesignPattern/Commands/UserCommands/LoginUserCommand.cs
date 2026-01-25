using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.UserCommands;
public class LoginUserCommand : IRequest<bool>
{
    public string UserNameOrEmail { get; set; }
    public string Password { get; set; }
}
