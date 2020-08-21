using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FelinesController : ControllerBase
  {
    private AnimalShelterContext _db;
    public FelinesController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Feline>> Get(string name, string species, string gender, int age)
    {
      var query = _db.Felines.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }
      if (gender != null)
      {
        query = query.Where(entry => entry.Gender == gender);
      }
      if (age > 0)
      {
        query = query.Where(entry => entry.Age == age);
      }
      return query.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Feline> GetAction(int id)
    {
      return _db.Felines.FirstOrDefault(entry => entry.FelineId == id);
    }

    [HttpPost]
    public void Post([FromBody] Feline feline)
    {
      _db.Felines.Add(feline);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Feline feline)
    {
      feline.FelineId = id;
      _db.Entry(feline).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var feline = _db.Felines.FirstOrDefault(entry => entry.FelineId == id);
      _db.Felines.Remove(feline);
      _db.SaveChanges();
    }
  }
}