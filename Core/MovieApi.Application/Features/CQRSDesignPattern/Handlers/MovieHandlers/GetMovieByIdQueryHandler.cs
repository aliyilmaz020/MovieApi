using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieByIdQueryHandler(MovieContext context)
{
    public async Task<GetMovieByIdQueryResult> Handler(GetMovieByIdQuery query)
    {
        var value = await context.Movies.FindAsync(query.MovieId);
        if (value != null)
            return new GetMovieByIdQueryResult
            {
                MovieId = value.MovieId,
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Duration = value.Duration,
                Rating = value.Rating,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status,
                Title = value.Title,
                CategoryId = value.CategoryId
            };
        return new GetMovieByIdQueryResult();
    }
}
