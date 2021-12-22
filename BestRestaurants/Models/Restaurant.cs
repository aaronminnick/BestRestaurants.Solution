namespace BestRestaurants.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public int CuisineId { get; set; }
    // public virtual Cuisine Cuisine { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Rating { get; set; }
    public string Location { get; set; }
  }
}