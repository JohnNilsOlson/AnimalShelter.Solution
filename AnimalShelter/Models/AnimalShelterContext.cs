using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Canine>()
        .HasData(
          new Canine { AnimalId = 1, CanineBreed = "Labrador Retreiver", Name = "Rex", Age = 7, Gender = "Female", Weight = 42, Bio = "Loves fetch!" },
          new Canine { AnimalId = 2, CanineBreed = "German Shepard", Name = "Ramona", Age = 2, Gender = "Female", Weight = 55, Bio = "Needs leash traning!" },
          new Canine { AnimalId = 3, CanineBreed = "Chihuahua", Name = "Ren", Age = 6, Gender = "Male", Weight = 12, Bio = "Yappy!" },
          new Canine { AnimalId = 4, CanineBreed = "Border Collie", Name = "Lassie", Age = 3, Gender = "Male", Weight = 47, Bio = "Very loyal!" },
          new Canine { AnimalId = 5, CanineBreed = "Dalmation", Name = "Spot", Age = 5, Gender = "Female", Weight = 41, Bio = "Courageous!" }
        );
      builder.Entity<Feline>()
        .HasData(
          new Feline { AnimalId = 6, FelineBreed = "Tabby", Name = "Whiskers", Age = 3, Gender = "Male", Weight = 10, Bio = "Loves belly rubs!" },
          new Feline { AnimalId = 7, FelineBreed = "Maine Coon", Name = "Simba", Age = 6, Gender = "Male", Weight = 12, Bio = "Ornery!" },
          new Feline { AnimalId = 8, FelineBreed = "Persian", Name = "Snowball", Age = 9, Gender = "Female", Weight = 2, Bio = "Loves chasing toys!" },
          new Feline { AnimalId = 9, FelineBreed = "Manx", Name = "Stimpy", Age = 4, Gender = "Male", Weight = 15, Bio = "Dumb but loveable!" },
          new Feline { AnimalId = 10, FelineBreed = "Sphynx", Name = "Fluffy", Age = 8, Gender = "Female", Weight = 9, Bio = "Hypo-allergenic!" }
        );
      builder.Entity<Bird>()
        .HasData(
          new Bird { AnimalId = 11, BirdBreed = "Parakeet", Name = "Chirpy", Age = 3, Gender = "Male", Weight = 1, Bio = "Very communicative!" },
          new Bird { AnimalId = 12, BirdBreed = "Zebra Finch", Name = "Stripes", Age = 12, Gender = "Female", Weight = 1, Bio = "Escape artist!" },
          new Bird { AnimalId = 13, BirdBreed = "Macaw", Name = "Blue", Age = 9, Gender = "Male", Weight = 3, Bio = "Not friendly!" },
          new Bird { AnimalId = 14, BirdBreed = "Bald Eagle", Name = "Sam", Age = 5, Gender = "Female", Weight = 12, Bio = "Regal!" },
          new Bird { AnimalId = 15, BirdBreed = "Emu", Name = "Ozzie", Age = 14, Gender = "Female", Weight = 45, Bio = "Extremely fast!" }
        );
      builder.Entity<Reptile>()
      .HasData(
        new Reptile { AnimalId = 16, ReptileBreed = "Snapping Turtle", Name = "Chompy", Age = 4, Gender = "Female", Weight = 1, Bio = "Will bite!" },
        new Reptile { AnimalId = 17, ReptileBreed = "Boa Constrictor", Name = "Kaa", Age = 13, Gender = "Female", Weight = 47, Bio = "Gives great hugs!" },
        new Reptile { AnimalId = 18, ReptileBreed = "Kimodo Dragon", Name = "Puff", Age = 5, Gender = "Male", Weight = 24, Bio = "Loves lounging in the sun!" },
        new Reptile { AnimalId = 19, ReptileBreed = "Alligator", Name = "Alli", Age = 8, Gender = "Female", Weight = 46, Bio = "Loves to wrestle!" },
        new Reptile { AnimalId = 20, ReptileBreed = "Gecko", Name = "Geico", Age = 2, Gender = "Male", Weight = 1, Bio = "Has a British Accent!" }
      );
      builder.Entity<Reptile>()
      .HasData(
        new Rodent { AnimalId = 21, RodentBreed = "Rat", Name = "Templeton", Age = 2, Gender = "Male", Weight = 1, Bio = "Loves cheese!" },
        new Rodent { AnimalId = 22, RodentBreed = "Mouse", Name = "Fievel", Age = 1, Gender = "Male", Weight = 1, Bio = "Goes west!" },
        new Rodent { AnimalId = 23, RodentBreed = "Hamster", Name = "Creampuff", Age = 3, Gender = "Female", Weight = 2, Bio = "Loves a good maze!" },
        new Rodent { AnimalId = 24, RodentBreed = "Guinea Pig", Name = "Cookie", Age = 4, Gender = "Female", Weight = 3, Bio = "Cuddly!" },
        new Rodent { AnimalId = 25, RodentBreed = "Weasel", Name = "Slinky", Age = 2, Gender = "Male", Weight = 3, Bio = "Loves to play hide and seek!" }
      );
      builder.Entity<Equine>()
      .HasData(
        new Equine { AnimalId = 26, EquineBreed = "Arabian", Name = "Artax", Age = 6, Gender = "Male", Weight = 1256, Bio = "Adventurous!" },
        new Equine { AnimalId = 27, EquineBreed = "Thoroughbred", Name = "Secretariat", Age = 12, Gender = "Male", Weight = 986, Bio = "Very fast!" },
        new Equine { AnimalId = 28, EquineBreed = "American Quarter", Name = "Black Beauty", Age = 5, Gender = "Male", Weight = 1124, Bio = "Kind hearted!" },
        new Equine { AnimalId = 29, EquineBreed = "Miniature", Name = "Einstein", Age = 7, Gender = "Female", Weight = 564, Bio = "Can do math!" },
        new Equine { AnimalId = 30, EquineBreed = "Appaloosa", Name = "Cojo Rojo", Age = 9, Gender = "Male", Weight = 1347, Bio = "A former movie star!" }
      );
    }
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
            : base(options) {  }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Canine> Canines { get; set; }
        public DbSet<Feline> Felines { get; set; }
        public DbSet<Reptile> Reptiles { get; set; }
        public DbSet<Rodent> Rodents { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Equine> Equines { get; set; }
  }
}