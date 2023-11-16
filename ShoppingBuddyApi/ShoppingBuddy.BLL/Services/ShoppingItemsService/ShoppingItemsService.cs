using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Services.ShoppingItemsService
{
    public class ShoppingItemsService : IShoppingItemsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ShoppingItem>> GetAllShoppingItems()
        {
            return await _unitOfWork.ShoppingItemRepository.GetAllShoppingItems();
        }
    }
}