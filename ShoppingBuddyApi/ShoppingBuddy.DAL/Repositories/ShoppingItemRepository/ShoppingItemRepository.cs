using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Repositories.ShoppingItemRepository
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShoppingItemRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<ShoppingItem>> GetAllShoppingItems()
        {
            return await _databaseContext.ShoppingItems.ToListAsync();
        }
    }
}