using ShoppingBuddy.BLL.DTOs.ShoppingItem;

namespace ShoppingBuddy.BLL.Dtos.Shopper
{
    public class ShopperResponseDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Image { get; set; }
        public List<ShoppingListItemResponseDto> ShoppingList { get; set; } = new();
    }
}