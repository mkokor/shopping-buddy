using ShoppingBuddy.BLL.Dtos.Shopper;

namespace ShoppingBuddy.BLL.Services.ShoppingService
{
    public interface IShoppingService
    {
        Task<List<ShopperResponseDto>> AddToShoppingList(int shopperId, int shoppingItemId);
    }
}