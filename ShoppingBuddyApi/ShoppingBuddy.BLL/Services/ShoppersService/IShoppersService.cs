using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.BLL.Services.ShoppersService
{
    public interface IShoppersService
    {
        Task<List<Shopper>> GetAllShoppers();        
    }
}