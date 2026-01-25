using System.ComponentModel.DataAnnotations;

namespace MovieApi.Domain.Entities;

public class RelatedMovie
{
    [Key]
    public int RelatedMovieId { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public bool IsWatch { get; set; }
}
