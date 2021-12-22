using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
  public class BestRestaurantsContext : DbContext
  {
    public DbSet<Cuisine> Cusines { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }

    public BestRestaurantsContext(DbContextOptions options) : base(options) { }
  }
}