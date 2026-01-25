namespace MovieApi.Application.Features.MediatorDesignPattern.Results.UserResults;
public class CheckUserEmailAndUsernameQueryResult
{
    public bool IsTakenEmail { get; set; } 
    public bool IsTakenUsername { get; set; }
}
