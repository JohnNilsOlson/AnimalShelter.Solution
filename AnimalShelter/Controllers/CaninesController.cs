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

    [HttpGet]
    public ActionResult<IEnumerable<Canine>> Get(string name, string species, string gender, int age)
    {
      var query = _db.Canines.AsQueryable();
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
      return _db.Canines.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Canine> GetAction(int id)
    {
      return _db.Canines.FirstOrDefault(entry => entry.CanineId == id);
    }

    [HttpPost]
    public void Post([FromBody] Canine canine)
    {
      _db.Canines.Add(canine);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Canine canine)
    {
      canine.CanineId = id;
      _db.Entry(canine).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var canine = _db.Canines.FirstOrDefault(entry => entry.CanineId == id);
      _db.Canines.Remove(canine);
      _db.SaveChanges();
    }
  }
}