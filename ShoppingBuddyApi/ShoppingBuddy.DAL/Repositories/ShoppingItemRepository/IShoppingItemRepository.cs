using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Repositories.ShoppingItemRepository
{
    public interface IShoppingItemRepository
    {
        Task<List<ShoppingItem>> GetAllShoppingItems();
    }
}