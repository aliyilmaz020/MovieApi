using MediatR;
using Microsoft.AspNetCore.Identity;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.UserQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.UserResults;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.UserHandlers;
public class CheckUserEmailAndUsernameQueryHandler(UserManager<AppUser> userManager) : IRequestHandler<CheckUserEmailAndUsernameQuery, CheckUserEmailAndUsernameQueryResult>
{
    public async Task<CheckUserEmailAndUsernameQueryResult> Handle(CheckUserEmailAndUsernameQuery request, CancellationToken cancellationToken)
    {
        var userByEmail = await userManager.FindByEmailAsync(request.Email);
        var userByUsername = await userManager.FindByNameAsync(request.UserName);

        return new()
        {
            IsTakenUsername = userByUsername != null,
            IsTakenEmail = userByEmail != null
        };

    }
}
