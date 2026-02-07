using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler(MovieContext context)
{
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var values = await context.Categories.ToListAsync();
        return values.Select(x=>new GetCategoryQueryResult
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName,
            Status = x.Status,
            Icon = x.Icon,
            Color = x.Color,
        }).ToList();
    }
}
