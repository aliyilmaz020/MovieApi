using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Exceptions;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.UserCommands;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.UserHandlers;
public class LoginUserCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : IRequestHandler<LoginUserCommand, bool>
{
    public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByNameAsync(request.UserNameOrEmail);
        if (user == null)
        {
            user = await userManager.FindByEmailAsync(request.UserNameOrEmail);
        }
        if (user == null)
        {
            return false;
        }
        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
        if (result.Succeeded)
        {
            return true;
        }
        return false;
    }
}
