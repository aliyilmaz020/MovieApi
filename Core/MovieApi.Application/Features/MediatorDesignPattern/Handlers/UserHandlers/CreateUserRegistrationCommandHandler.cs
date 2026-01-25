using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.UserCommands;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.UserHandlers;
public class CreateUserRegistrationCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<CreateUserRegistrationCommand, object>
{
    public async Task<object> Handle(CreateUserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            Name = request.Name,
            Surname = request.Surname,
            UserName = request.UserName,
            Email = request.Email
        };
        var result = await userManager.CreateAsync(user, request.Password);
        if(result.Succeeded)
        {
            return true;
        }
        else
        {
            return result.Errors;
        }
        
    }
}
