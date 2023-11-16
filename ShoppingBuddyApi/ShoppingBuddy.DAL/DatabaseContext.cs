using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;
namespace ShoppingBuddy.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Shopper> Shoppers { get; init; }
        public DbSet<ShoppingItem> ShoppingItems { get; init; }

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
                    new() { Id = 1, FirstName = "John", LastName = "Doe" },
                    new() { Id = 2, FirstName = "Emily", LastName = "Johnson" },
                    new() { Id = 3, FirstName = "Benjamin", LastName = "Smith" },
                    new() { Id = 4, FirstName = "Ava", LastName = "Williams" },
                    new() { Id = 5, FirstName = "Olivia", LastName = "Davis" }
                });
            #endregion

            #region ShoppingItem
            modelBuilder.Entity<ShoppingItem>()
                .ToTable("shopping_items");

            modelBuilder.Entity<ShoppingItem>()
                .Property(shoppingItem => shoppingItem.Id)
                .HasColumnName("id");

            modelBuilder.Entity<ShoppingItem>()
                .Property(shoppingItem => shoppingItem.Title)
                .HasColumnName("title");

            modelBuilder.Entity<ShoppingItem>()
                .Property(shoppingItem => shoppingItem.Avilable)
                .HasColumnName("available");

            modelBuilder.Entity<ShoppingItem>()
                .HasData(new List<ShoppingItem>
                {
                    new() { Id = 1, Title = "Milk", Image = "/images/shopping-items/milk.png", Avilable = true },
                    new() { Id = 2, Title = "Apple juice", Image = "/images/shopping-items/apple-juice.png", Avilable = true },
                    new() { Id = 3, Title = "Chocolate", Image = "/images/shopping-items/chocolate.png", Avilable = true },
                    new() { Id = 4, Title = "Chips", Image = "/images/shopping-items/chips.png", Avilable = true },
                    new() { Id = 5, Title = "Bread", Image = "/images/shopping-items/bread.png", Avilable = true },
                });
            #endregion
        }
    }
}