namespace ShoppingBuddy.DAL.Entities
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }
        public bool Avilable { get; set; }
    }
}