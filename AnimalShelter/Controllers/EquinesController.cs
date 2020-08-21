using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EquinesController : ControllerBase
  {
    private AnimalShelterContext _db;
    public EquinesController(AnimalShelterContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Returns all equine entries from the database, filterable by name, breed, gender and/or age.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Equine>> Get(string name, string breed, string gender, int age)
    {
      var query = _db.Equines.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.EquineBreed == breed);
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
    /// Returns a single equine entry from the database, by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Equine> GetAction(int id)
    {
      return _db.Equines.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Adds a equine entry to the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Equines
    ///     {
    ///        "equinebreed": "Arabian",
    ///        "name": "Mr. Ed",
    ///        "gender": "Male",
    ///        "age": 7,
    ///        "weight": 1243,
    ///        "bio": "Very chatty."
    ///     }
    ///
    /// </remarks>
    /// <param name="equine"></param>
    /// <response code="200">Equine entry successfully added to database.</response>
    /// <response code="400">Equine entry is not added to the database.</response>
    [HttpPost]
    public void Post([FromBody] Equine equine)
    {
      _db.Equines.Add(equine);
      _db.SaveChanges();
    }

    /// <summary>
    /// Updates a equine entry in the database, by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Equines
    ///     {
    ///        "equinebreed": "Arabian",
    ///        "name": "Mr. Ed",
    ///        "gender": "Male",
    ///        "age": 7,
    ///        "weight": 1243,
    ///        "bio": "Very chatty."
    ///     }
    ///
    /// </remarks>
    /// <param name="equine"></param>
    /// <response code="200">Equine database entry successfully updated.</response>
    /// <response code="400">Equine database entry not updated.</response>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Equine equine)
    {
      equine.AnimalId = id;
      _db.Entry(equine).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Removes a equine entry from the database, by id.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var equine = _db.Equines.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Equines.Remove(equine);
      _db.SaveChanges();
    }
  }
}