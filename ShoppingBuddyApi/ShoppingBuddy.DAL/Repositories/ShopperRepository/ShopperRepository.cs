using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Repositories.ShopperRepository
{
    public class ShopperRepository : IShopperRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShopperRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Shopper>> GetAll()
        {
            return await _databaseContext.Shoppers.ToListAsync();
        }

        public async Task<Shopper?> GetById(int id)
        {
            var shopper = await _databaseContext.Shoppers.FindAsync(id);
            return shopper;
        }
    }
}