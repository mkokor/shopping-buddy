using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Other
{
    public class ShoppingList
    {
        public required Shopper Shopper { get; set; }
        public required List<ShoppingListItem> ShoppingItems { get; set; }
    }
}