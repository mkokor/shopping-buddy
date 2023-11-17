using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingBuddy.DAL.Entities
{
    public class ShoppingListItem
    {
        public int Id { get; set; }

        [ForeignKey("Shopper")]
        public int ShopperId { get; set; }
        public Shopper? Shopper { get; set; }

        [ForeignKey("ShoppingItem")]
        public int ShoppingItemId { get; set; }
        public ShoppingItem? ShoppingItem { get; set; }
    }
}