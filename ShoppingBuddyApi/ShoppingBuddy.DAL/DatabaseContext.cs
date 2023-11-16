using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;
namespace ShoppingBuddy.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Shopper> Shoppers { get; init; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Shopper
            modelBuilder.Entity<Shopper>()
                .ToTable("shoppers");

            modelBuilder.Entity<Shopper>()
                .Property(shopper => shopper.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Shopper>()
                .Property(shopper => shopper.FirstName)
                .HasColumnName("first_name");

            modelBuilder.Entity<Shopper>()
                .Property(shopper => shopper.LastName)
                .HasColumnName("last_name");
            
            modelBuilder.Entity<Shopper>()
                .HasData(new List<Shopper> 
                {
                    new() { Id = 1, FirstName = "John", LastName = "Doe" }
                });
            #endregion
        }
    }
}