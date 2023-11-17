using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Repositories.ShoppingItemRepository
{
    public interface IShoppingItemRepository
    {
        Task<List<ShoppingItem>> GetAll();

        Task<ShoppingItem?> GetById(int id);
    }
}