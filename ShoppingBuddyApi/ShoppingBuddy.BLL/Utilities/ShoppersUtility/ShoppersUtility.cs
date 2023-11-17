using AutoMapper;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.BLL.DTOs.ShoppingItem;
using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Utilities.ShoppersUtility
{
    public class ShoppersUtility
    {

        public static async Task<List<ShopperResponseDto>> ConfigureShoppingLists(List<Shopper> shoppers, IUnitOfWork unitOfWork, IMapper mapper)
        {
            var shoppingLists = await unitOfWork.ShoppingListItemRepository.GroupByShopper();
            var allShoppersDto = mapper.Map<List<ShopperResponseDto>>(shoppers);

            allShoppersDto.ForEach(shopper =>
            {
                var shoppingList = shoppingLists.FirstOrDefault(shoppingList => shoppingList.Shopper.Id == shopper.Id);
                if (shoppingList is null) return;
                var shoppingItems = shoppingList.ShoppingItems.Select(shoppingItem => shoppingItem.ShoppingItem).ToList();
                shoppingItems.ForEach(shoppingItem =>
                {
                    if (shopper.ShoppingList.Find(shoppingListItem => shoppingListItem.Id == shoppingItem!.Id) is not null)
                        return;
                    var shoppingListItem = mapper.Map<ShoppingListItemResponseDto>(shoppingItem);
                    shoppingListItem.Quantity = shoppingItems.FindAll(item => item!.Id == shoppingItem!.Id).Count;
                    shopper.ShoppingList.Add(shoppingListItem);
                });
            });

            return allShoppersDto;
        }

    }
}