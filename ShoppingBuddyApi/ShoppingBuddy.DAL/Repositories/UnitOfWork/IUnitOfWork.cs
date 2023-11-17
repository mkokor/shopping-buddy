using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBuddy.DAL.Repositories.ShopperRepository;
using ShoppingBuddy.DAL.Repositories.ShoppingItemRepository;
using ShoppingBuddy.DAL.Repositories.ShoppingListRepository;

namespace ShoppingBuddy.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IShopperRepository ShopperRepository { get; init; }
        IShoppingItemRepository ShoppingItemRepository { get; init; }
        IShoppingListItemRepository ShoppingListItemRepository { get; init; }

        Task SaveAsync();
    }
}