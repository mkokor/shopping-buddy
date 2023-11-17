using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Other;

namespace ShoppingBuddy.DAL.Repositories.ShoppingListRepository
{
    public interface IShoppingListItemRepository
    {
        Task<ShoppingListItem> Create(ShoppingListItem shoppingListItem);

        Task<List<ShoppingList>> GroupByShopper();
    }
}