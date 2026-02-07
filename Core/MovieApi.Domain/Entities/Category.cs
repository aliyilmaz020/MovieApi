namespace MovieApi.Domain.Entities;
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
    public bool Status { get; set; }
    public ICollection<Movie> Movies { get; set; }
}
