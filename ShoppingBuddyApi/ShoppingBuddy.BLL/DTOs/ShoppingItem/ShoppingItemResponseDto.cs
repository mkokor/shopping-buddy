namespace ShoppingBuddy.BLL.DTOs.ShoppingItem
{
    public class ShoppingItemResponseDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }
    }
}