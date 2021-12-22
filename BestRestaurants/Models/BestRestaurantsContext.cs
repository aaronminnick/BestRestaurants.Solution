using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
  public class BestRestaurantsContext : DbContext
  {
    public DbSet<Item> Items { get; set; }

    public BestRestaurantsContext(DbContextOptions options) : base(options) { }
  }
}