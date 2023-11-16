namespace ShoppingBuddy.BLL.Dtos.Shopper
{
    public class ShopperResponseDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}