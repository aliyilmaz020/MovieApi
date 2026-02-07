namespace MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;

public class GetCategoryQueryResult
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public bool Status { get; set; }
}
