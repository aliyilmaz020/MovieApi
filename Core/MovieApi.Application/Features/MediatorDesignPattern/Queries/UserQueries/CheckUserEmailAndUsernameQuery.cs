using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.UserResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.UserQueries;
public class CheckUserEmailAndUsernameQuery : IRequest<CheckUserEmailAndUsernameQueryResult>
{
    public string Email { get; set; }
    public string UserName { get; set; }
}
