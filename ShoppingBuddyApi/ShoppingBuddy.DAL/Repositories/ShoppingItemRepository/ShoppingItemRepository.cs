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

        public async Task<List<ShoppingItem>> GetAll()
        {
            return await _databaseContext.ShoppingItems.ToListAsync();
        }

        public async Task<ShoppingItem?> GetById(int id)
        {
            return await _databaseContext.ShoppingItems.FindAsync(id);
        }
    }
}