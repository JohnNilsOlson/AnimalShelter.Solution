using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BirdsController : ControllerBase
  {
    private AnimalShelterContext _db;
    public BirdsController(AnimalShelterContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Returns all bird entries from the database, filterable by name, breed, gender and/or age.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Bird>> Get(string name, string breed, string gender, int age)
    {
      var query = _db.Birds.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.BirdBreed == breed);
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
    /// Returns a single bird entry from the database, by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Bird> GetAction(int id)
    {
      return _db.Birds.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Adds a bird entry to the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Birds
    ///     {
    ///        "birdbreed": "Cockatoo",
    ///        "name": "Beaker",
    ///        "gender": "Male",
    ///        "age": 6,
    ///        "weight": 2,
    ///        "bio": "Knows all the swear words."
    ///     }
    ///
    /// </remarks>
    /// <param name="bird"></param>
    /// <response code="200">Bird entry successfully added to database.</response>
    /// <response code="400">Bird entry is not added to the database.</response>
    [HttpPost]
    public void Post([FromBody] Bird bird)
    {
      _db.Birds.Add(bird);
      _db.SaveChanges();
    }

    /// <summary>
    /// Updates a bird entry in the database, by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Birds
    ///     {
    ///        "birdbreed": "Cockatoo",
    ///        "name": "Beaker",
    ///        "gender": "Male",
    ///        "age": 6,
    ///        "weight": 2,
    ///        "bio": "Knows all the swear words."
    ///     }
    ///
    /// </remarks>
    /// <param name="bird"></param>
    /// <response code="200">Bird database entry successfully updated.</response>
    /// <response code="400">Bird database entry not updated.</response>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Bird bird)
    {
      bird.AnimalId = id;
      _db.Entry(bird).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Removes a bird entry from the database, by id.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var bird = _db.Birds.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Birds.Remove(bird);
      _db.SaveChanges();
    }
  }
}