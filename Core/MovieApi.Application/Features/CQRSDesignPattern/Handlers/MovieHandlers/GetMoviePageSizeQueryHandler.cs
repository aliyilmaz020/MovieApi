using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
public class GetMoviePageSizeQueryHandler(MovieContext context)
{
    public async Task<object> Handler(GetMoviePageSizeQuery query)
    {
        if (query.Page <= 0)
            query.Page = 1;
        var movies = context.Movies.Skip((query.Page - 1) * 6).Take(6);
        int count = await context.Movies.CountAsync();
        return new { Movies = movies, Count = count };
    }
}
