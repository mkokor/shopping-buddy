using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.DAL.Repositories.ShopperRepository
{
    public interface IShopperRepository
    {
        Task<List<Shopper>> GetAll();

        Task<Shopper?> GetById(int id);
    }
}