using ShoppingBuddy.BLL.DTOs.ShoppingItem;

namespace ShoppingBuddy.BLL.Services.ShoppingItemsService
{
    public interface IShoppingItemsService
    {
        Task<List<ShoppingItemResponseDto>> GetAllShoppingItems();
    }
}