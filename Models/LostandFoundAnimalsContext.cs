using Microsoft.EntityFrameworkCore;

namespace LostandFoundAnimals.Models
{
    public class LostandFoundAnimalsContext : DbContext
    {
        public LostandFoundAnimalsContext(DbContextOptions<LostandFoundAnimalsContext> options)
            : base(options)
        {
        }

        public DbSet<LostandFoundAnimals.Models.Address> Address { get; set; }
        public DbSet<LostandFoundAnimals.Models.Breed> Breed { get; set; }
        public DbSet<LostandFoundAnimals.Models.Animal> Animal { get; set; }
        public DbSet<LostandFoundAnimals.Models.Post> Post { get; set; }
        public DbSet<LostandFoundAnimals.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Address");
            modelBuilder.Entity<Breed>().ToTable("Breed");
            modelBuilder.Entity<Animal>().ToTable("Animal");
            modelBuilder.Entity<Post>().ToTable("Post");

            //modelBuilder.Entity<Post>()
            //            .HasKey(p => p.AnimalID);
            //modelBuilder.Entity<Post>()
                        //.HasOne(p => p.Animal)
                        //.WithOne(i => i.Post)
                        //.HasForeignKey<Animal>(b => b.PostID);
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
