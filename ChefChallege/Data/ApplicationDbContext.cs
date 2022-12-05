using Microsoft.EntityFrameworkCore;
using ChefChallege.Models;

namespace ChefChallege.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<DesertRecipe> DesertRecipe { get; set; }
        public DbSet<SoupRecipe> SoupRecipe { get; set; }
        public DbSet<DinnerRecipe> DinnerRecipe { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}
