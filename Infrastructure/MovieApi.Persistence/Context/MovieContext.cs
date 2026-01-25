using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using MovieApi.Domain.Entities.Identity;

namespace MovieApi.Persistence.Context
{
    public class MovieContext(DbContextOptions<MovieContext> options) : IdentityDbContext<AppUser,AppRole,int>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cast> Casts { get; set; }
    }
}
