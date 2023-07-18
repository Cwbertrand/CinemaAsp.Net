using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<CrudApplication.Models.Movies> Movies { get; set; } = default!;
    }
}
