using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBuddy.DAL.Repositories.ShopperRepository;
using ShoppingBuddy.DAL.Repositories.ShoppingItemRepository;

namespace ShoppingBuddy.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IShopperRepository ShopperRepository { get; init; }
        IShoppingItemRepository ShoppingItemRepository { get; init; }

        Task SaveAsync();
    }
}