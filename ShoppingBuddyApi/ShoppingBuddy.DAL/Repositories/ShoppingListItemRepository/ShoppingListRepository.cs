using Microsoft.EntityFrameworkCore;
using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Other;

namespace ShoppingBuddy.DAL.Repositories.ShoppingListRepository
{
    public class ShoppingListItemRepository : IShoppingListItemRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ShoppingListItemRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ShoppingListItem> Create(ShoppingListItem shoppingListItem)
        {
            await _databaseContext.ShoppingListItems.AddAsync(shoppingListItem);
            return shoppingListItem;
        }

        public async Task<List<ShoppingList>> GroupByShopper()
        {
            return await _databaseContext.ShoppingListItems.Include(shoppingListItem => shoppingListItem.Shopper)
                                                           .Include(shoppingListItem => shoppingListItem.ShoppingItem)
                                                           .GroupBy(shoppingListItem => shoppingListItem.Shopper)
                                                           .Select(shoppingList => new ShoppingList { Shopper = shoppingList.Key!, ShoppingItems = shoppingList.ToList() })
                                                           .ToListAsync();
        }
    }
}