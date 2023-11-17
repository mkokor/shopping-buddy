namespace ShoppingBuddy.BLL.DTOs.ShoppingItem
{
    public class ShoppingListItemResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }
        public int Quantity { get; set; }
    }
}