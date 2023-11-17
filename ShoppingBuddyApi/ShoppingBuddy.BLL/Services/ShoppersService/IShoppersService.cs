using ShoppingBuddy.BLL.Dtos.Shopper;

namespace ShoppingBuddy.BLL.Services.ShoppersService
{
    public interface IShoppersService
    {
        Task<List<ShopperResponseDto>> GetAllShoppers();
    }
}