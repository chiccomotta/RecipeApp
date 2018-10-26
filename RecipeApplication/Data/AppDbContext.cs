using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Query Filter, vedi: https://docs.microsoft.com/it-it/ef/core/querying/filters 
            modelBuilder.Entity<Recipe>().HasQueryFilter(r => r.IsDeleted == false);
        }
    }
}

