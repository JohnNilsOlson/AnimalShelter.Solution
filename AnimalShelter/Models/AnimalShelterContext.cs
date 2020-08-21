using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options) {  }
        public DbSet<Canine> Canines { get; set; }
        public DbSet<Feline> Felines { get; set; }
        public DbSet<Animal> Animals { get; set; }
  }
}