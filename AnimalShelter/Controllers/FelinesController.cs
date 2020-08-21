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

    /// <summary>
    /// Returns all feline entries from the database, filterable by name, breed, gender and/or age.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Feline>> Get(string name, string breed, string gender, int age)
    {
      var query = _db.Felines.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.FelineBreed == breed);
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

    /// <summary>
    /// Returns a single feline entry from the database, by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Feline> GetAction(int id)
    {
      return _db.Felines.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Adds a feline entry to the database.
    /// </summary>
    [HttpPost]
    public void Post([FromBody] Feline feline)
    {
      _db.Felines.Add(feline);
      _db.SaveChanges();
    }

    /// <summary>
    /// Updates a feline entry in the database, by id.
    /// </summary>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Feline feline)
    {
      feline.AnimalId = id;
      _db.Entry(feline).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Removes a canine entry from the database, by id.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var feline = _db.Felines.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Felines.Remove(feline);
      _db.SaveChanges();
    }
  }
}