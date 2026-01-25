using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.UserCommands;
public class CreateUserRegistrationCommand : IRequest<object>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
