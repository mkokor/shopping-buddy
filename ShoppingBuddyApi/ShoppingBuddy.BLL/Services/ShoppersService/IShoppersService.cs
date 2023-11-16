using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.BLL.Services.ShoppersService
{
    public interface IShoppersService
    {
        Task<List<ShopperResponseDto>> GetAllShoppers();
    }
}