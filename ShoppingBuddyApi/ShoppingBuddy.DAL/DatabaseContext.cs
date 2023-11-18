using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Shopper> Shoppers { get; init; }
        public DbSet<ShoppingItem> ShoppingItems { get; init; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; init; }

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
                .Property(shopper => shopper.Image)
                .HasColumnName("image");

            modelBuilder.Entity<Shopper>()
                .HasData(new List<Shopper>
                {
                    new() { Id = 1, FirstName = "John", LastName = "Doe", Image = "/images/shoppers/john-doe.png" },
                    new() { Id = 2, FirstName = "Emily", LastName = "Johnson", Image = "/images/shoppers/emily-johnson.png" },
                    new() { Id = 3, FirstName = "Benjamin", LastName = "Smith", Image = "/images/shoppers/benjamin-smith.png" },
                    new() { Id = 4, FirstName = "Ava", LastName = "Williams", Image = "/images/shoppers/ava-williams.png" },
                    new() { Id = 5, FirstName = "Olivia", LastName = "Davis", Image = "/images/shoppers/olivia-davis.png" }
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
                .Property(shoppingItem => shoppingItem.Image)
                .HasColumnName("image");

            modelBuilder.Entity<ShoppingItem>()
                .HasData(new List<ShoppingItem>
                {
                    new() { Id = 1, Title = "Milk", Image = "/images/shopping-items/milk.png" },
                    new() { Id = 2, Title = "Apple juice", Image = "/images/shopping-items/apple-juice.png" },
                    new() { Id = 3, Title = "Chocolate", Image = "/images/shopping-items/chocolate.png" },
                    new() { Id = 4, Title = "Chips", Image = "/images/shopping-items/chips.png" },
                    new() { Id = 5, Title = "Bread", Image = "/images/shopping-items/bread.png" },
                });
            #endregion

            #region ShoppingList
            modelBuilder.Entity<ShoppingListItem>()
                .ToTable("shopping_list_items");

            modelBuilder.Entity<ShoppingListItem>()
                .Property(shoppingList => shoppingList.Id)
                .HasColumnName("id");

            modelBuilder.Entity<ShoppingListItem>()
                .Property(shoppingList => shoppingList.ShopperId)
                .HasColumnName("shopper_id");

            modelBuilder.Entity<ShoppingListItem>()
                .Property(shoppingList => shoppingList.ShoppingItemId)
                .HasColumnName("shopping_item_id");
            #endregion
        }
    }
}