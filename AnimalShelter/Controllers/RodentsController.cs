using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RodentsController : ControllerBase
  {
    private AnimalShelterContext _db;
    public RodentsController(AnimalShelterContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Returns all rodent entries from the database, filterable by name, breed, gender and/or age.
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Rodent>> Get(string name, string breed, string gender, int age)
    {
      var query = _db.Rodents.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.RodentBreed == breed);
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
    /// Returns a single rodent entry from the database, by id.
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Rodent> GetAction(int id)
    {
      return _db.Rodents.FirstOrDefault(entry => entry.AnimalId == id);
    }

    /// <summary>
    /// Adds a rodent entry to the database.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Rodents
    ///     {
    ///        "rodentbreed": "Rat",
    ///        "name": "Templeton",
    ///        "gender": "Male",
    ///        "age": 3,
    ///        "weight": 1,
    ///        "bio": "Will chew through your computer cables."
    ///     }
    ///
    /// </remarks>
    /// <param name="rodent"></param>
    /// <response code="200">Rodent entry successfully added to database.</response>
    /// <response code="400">Rodent entry is not added to the database.</response>
    [HttpPost]
    public void Post([FromBody] Rodent rodent)
    {
      _db.Rodents.Add(rodent);
      _db.SaveChanges();
    }

    /// <summary>
    /// Updates a rodent entry in the database, by id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /Rodents
    ///     {
    ///        "rodentbreed": "Rat",
    ///        "name": "Templeton",
    ///        "gender": "Male",
    ///        "age": 3,
    ///        "weight": 1,
    ///        "bio": "Will chew through your computer cables."
    ///     }
    ///
    /// </remarks>
    /// <param name="rodent"></param>
    /// <response code="200">Rodent database entry successfully updated.</response>
    /// <response code="400">Rodent database entry not updated.</response>
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Rodent rodent)
    {
      rodent.AnimalId = id;
      _db.Entry(rodent).State = EntityState.Modified;
      _db.SaveChanges();
    }

    /// <summary>
    /// Removes a rodent entry from the database, by id.
    /// </summary>
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var rodent = _db.Rodents.FirstOrDefault(entry => entry.AnimalId == id);
      _db.Rodents.Remove(rodent);
      _db.SaveChanges();
    }
  }
}