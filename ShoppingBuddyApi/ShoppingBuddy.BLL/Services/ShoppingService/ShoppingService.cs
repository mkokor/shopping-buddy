using AutoMapper;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.BLL.Exceptions;
using ShoppingBuddy.BLL.Utilities.ShoppersUtility;
using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Services.ShoppingService
{
    public class ShoppingService : IShoppingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private async Task CheckShoppingItemAvailability(ShoppingItem shoppingItem, Shopper shopper)
        {
            var shoppingLists = await _unitOfWork.ShoppingListItemRepository.GroupByShopper();
            int quantity = 0;
            bool approved = false;

            shoppingLists.ForEach(shoppingList =>
            {
                if (shoppingList.ShoppingItems.FirstOrDefault(item => item.ShoppingItemId == shoppingItem.Id) is not null) quantity++;
                if (shoppingList.Shopper.Id == shopper.Id)
                {
                    approved = true;
                    return;
                }
            });

            if (approved) return;
            if (quantity == 3) throw new BadRequestException("Requested shopping item is not available for this shopper.");
        }

        public async Task<List<ShopperResponseDto>> AddToShoppingList(int shopperId, int shoppingItemId)
        {
            var shopper = await _unitOfWork.ShopperRepository.GetById(shopperId) ?? throw new NotFoundException("Shopper with provided id could not be found.");
            var shoppingItem = await _unitOfWork.ShoppingItemRepository.GetById(shoppingItemId) ?? throw new NotFoundException("Shopping item with provided id could not be found.");

            await CheckShoppingItemAvailability(shoppingItem, shopper);

            await _unitOfWork.ShoppingListItemRepository.Create(new ShoppingListItem
            {
                ShopperId = shopper.Id,
                ShoppingItemId = shoppingItem.Id
            });
            await _unitOfWork.SaveAsync();

            var allShoppers = await _unitOfWork.ShopperRepository.GetAll();

            return await ShoppersUtility.ConfigureShoppingLists(allShoppers, _unitOfWork, _mapper);
        }

        public async Task<List<ShopperResponseDto>> DecreaseQuantity(int shopperId, int shoppingItemId)
        {
            _ = await _unitOfWork.ShopperRepository.GetById(shopperId) ?? throw new NotFoundException("Shopper with provided id could not be found.");
            _ = await _unitOfWork.ShoppingItemRepository.GetById(shoppingItemId) ?? throw new NotFoundException("Shopping item with provided id could not be found.");
            var shoppingListItem = await _unitOfWork.ShoppingListItemRepository.GetByShopperAndItemId(shopperId, shoppingItemId);

            if (shoppingListItem != null)
            {
                _unitOfWork.ShoppingListItemRepository.Delete(shoppingListItem);
                await _unitOfWork.SaveAsync();
            }

            var allShoppers = await _unitOfWork.ShopperRepository.GetAll();

            return await ShoppersUtility.ConfigureShoppingLists(allShoppers, _unitOfWork, _mapper);
        }
    }
}