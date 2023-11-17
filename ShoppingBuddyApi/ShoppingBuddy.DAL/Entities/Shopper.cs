namespace ShoppingBuddy.DAL.Entities
{
    public class Shopper
    {

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Image { get; set; }
    }
}