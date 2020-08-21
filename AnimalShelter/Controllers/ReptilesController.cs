using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReptilesController : ControllerBase
  {
    private AnimalShelterContext _db;
    public ReptilesController(AnimalShelterContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Returns all reptile entries from the database, filterable by name, breed, gender and/or age.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Reptile>> Get(string name, string breed, string gender, int age)
    {
      var query = _db.Reptiles.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.ReptileBreed == breed);
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
    /// Returns a single reptile entry from the database, by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Reptile> GetAction(int id)
    {
      return _db.Reptiles.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Adds a reptile entry to the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Reptiles
    ///     {
    ///        "reptilebreed": "Snapping Turtle",
    ///        "name": "Shelly",
    ///        "gender": "Male",
    ///        "age": 15,
    ///        "weight": 3,
    ///        "bio": "Will bite."
    ///     }
    ///
    /// </remarks>
    /// <param name="reptile"></param>
    /// <response code="200">Reptile entry successfully added to database.</response>
    /// <response code="400">Reptile entry is not added to the database.</response>
    [HttpPost]
    public void Post([FromBody] Reptile reptile)
    {
      _db.Reptiles.Add(reptile);
      _db.SaveChanges();
    }

    /// <summary>
    /// Updates a reptile entry in the database, by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Reptiles
    ///     {
    ///        "reptilebreed": "Snapping Turtle",
    ///        "name": "Shelly",
    ///        "gender": "Male",
    ///        "age": 15,
    ///        "weight": 3,
    ///        "bio": "Will bite."
    ///     }
    ///
    /// </remarks>
    /// <param name="reptile"></param>
    /// <response code="200">Reptile database entry successfully updated.</response>
    /// <response code="400">Reptile database entry not updated.</response>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Reptile reptile)
    {
      reptile.AnimalId = id;
      _db.Entry(reptile).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Removes a reptile entry from the database, by id.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var reptile = _db.Reptiles.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Reptiles.Remove(reptile);
      _db.SaveChanges();
    }
  }
}