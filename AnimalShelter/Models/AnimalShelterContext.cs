using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Canine>()
        .HasData(
          new Canine { AnimalId = 1, CanineBreed = "Labrador Retreiver", Name = "Rex", Age = 7, Gender = "Female", Weight = 42, Bio = "Loves fetch!" }
        );
      builder.Entity<Feline>()
        .HasData(
          new Feline { AnimalId = 2, FelineBreed = "Tabby", Name = "Whiskers", Age = 3, Gender = "Male", Weight = 10, Bio = "Loves belly rubs!" }
        );
    }
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options) {  }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Canine> Canines { get; set; }
        public DbSet<Feline> Felines { get; set; }
        public DbSet<Reptile> Reptiles { get; set; }
        public DbSet<Rodent> Rodents { get; set; }
  }
}