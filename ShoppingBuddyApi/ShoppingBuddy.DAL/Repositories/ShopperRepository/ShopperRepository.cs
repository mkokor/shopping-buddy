using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Repositories.ShopperRepository
{
    public class ShopperRepository : IShopperRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShopperRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }

        public async Task<List<Shopper>> GetAllShoppers()
        {
            return await _databaseContext.Shoppers.ToListAsync();
        }
    }
}