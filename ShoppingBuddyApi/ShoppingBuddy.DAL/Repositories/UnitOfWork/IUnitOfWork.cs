using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBuddy.DAL.Repositories.ShopperRepository;

namespace ShoppingBuddy.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IShopperRepository ShopperRepository { get; init; }

        Task SaveAsync();
    }
}