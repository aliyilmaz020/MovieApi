using MovieApi.Application.Identity;
using MovieApi.Domain.Entities.Identity;
using MovieApi.Persistence.Context;

namespace MovieApi.WebApi;

public static class ServiceRegistration
{
    public static void AddWebApiServices(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        }).AddEntityFrameworkStores<MovieContext>()
        .AddErrorDescriber<CustomIdentityErrorDescriber>();
    }
}
