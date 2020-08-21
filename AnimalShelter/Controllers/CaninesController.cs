using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CaninesController : ControllerBase
  {
    private AnimalShelterContext _db;
    public CaninesController(AnimalShelterContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Returns all canine entries from the database, filterable by name, breed, gender and/or age.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Canine>> Get(string name, string breed, string gender, int age)
    {
      var query = _db.Canines.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.CanineBreed == breed);
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
    /// Returns a single canine entry from the database, by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Canine> GetAction(int id)
    {
      return _db.Canines.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Adds a canine entry to the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Canines
    ///     {
    ///        "caninebreed": "German Shepard",
    ///        "name": "Ramona",
    ///        "gender": "Female",
    ///        "age": 2,
    ///        "weight": 55,
    ///        "bio": "Sweet, sociable dog with a lot of energy!  Needs work on leash manners."
    ///     }
    ///
    /// </remarks>
    /// <param name="canine"></param>
    /// <response code="200">Canine entry successfully added to database.</response>
    /// <response code="400">Canine entry is not added to the database.</response>
    [HttpPost]
    public void Post([FromBody] Canine canine)
    {
      _db.Canines.Add(canine);
      _db.SaveChanges();
    }

    /// <summary>
    /// Updates a canine entry in the database, by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Canines
    ///     {
    ///        "caninebreed": "German Shepard",
    ///        "name": "Ramona",
    ///        "gender": "Female",
    ///        "age": 2,
    ///        "weight": 55,
    ///        "bio": "Sweet, sociable dog with a lot of energy!  Needs work on leash manners."
    ///     }
    ///
    /// </remarks>
    /// <param name="canine"></param>
    /// <response code="200">Canine database entry successfully updated.</response>
    /// <response code="400">Canine database entry not updated.</response>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Canine canine)
    {
      canine.AnimalId = id;
      _db.Entry(canine).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Removes a canine entry from the database, by id.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var canine = _db.Canines.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Canines.Remove(canine);
      _db.SaveChanges();
    }
  }
}