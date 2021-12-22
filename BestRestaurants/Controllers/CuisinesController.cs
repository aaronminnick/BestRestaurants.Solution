using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurants.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantsContext _db;
    
    public CuisinesController(BestRestaurantsContext db)
    {
      _db = db;
      if ((_db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == 0)) == null)
      {
        Cuisine uncategorized = new Cuisine();
        uncategorized.Name = "Uncategorized";
        uncategorized.CuisineId = 0;
        _db.Cuisines.Add(uncategorized);
        _db.SaveChanges();
      }
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Entry(cuisine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      _db.Cuisines.Remove(thisCuisine);
      List<Restaurant> reassigns = (from restaurant in _db.Restaurants where restaurant.CuisineId == id select restaurant).ToList();
      foreach(Restaurant restaurant in reassigns)
      {
        restaurant.CuisineId = 0;
        _db.Entry(restaurant).State = EntityState.Modified;
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }    
}