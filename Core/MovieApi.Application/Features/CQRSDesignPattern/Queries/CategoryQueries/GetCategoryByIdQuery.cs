namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

public class GetCategoryByIdQuery(int categoryId)
{
    public int CategoryId { get; set; } = categoryId;
}
