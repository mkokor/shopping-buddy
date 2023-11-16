using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.BLL.Services.ShoppingItemsService
{
    public interface IShoppingItemsService
    {
        Task<List<ShoppingItem>> GetAllShoppingItems();
    }
}