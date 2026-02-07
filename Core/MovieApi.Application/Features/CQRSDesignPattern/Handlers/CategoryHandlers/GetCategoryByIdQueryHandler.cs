using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler(MovieContext context)
{
    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var value = await context.Categories.FindAsync(query.CategoryId);
        if(value == null)
        {
            throw new Exception("yok");
        }
        return new GetCategoryByIdQueryResult
        {
            CategoryId = value.CategoryId,
            CategoryName = value.CategoryName,
            Status = value.Status,
            Icon = value.Icon,
            Color = value.Color,
        };
    }
}
