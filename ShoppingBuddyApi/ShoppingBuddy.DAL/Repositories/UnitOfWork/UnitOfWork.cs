using ShoppingBuddy.DAL.Repositories.ShopperRepository;
using ShoppingBuddy.DAL.Repositories.ShoppingItemRepository;

namespace ShoppingBuddy.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IShopperRepository ShopperRepository { get; init; }
        public IShoppingItemRepository ShoppingItemRepository { get; init; }

        public UnitOfWork(DatabaseContext databaseContext)
        {
            ShopperRepository = new ShopperRepository.ShopperRepository(databaseContext);
            ShoppingItemRepository = new ShoppingItemRepository.ShoppingItemRepository(databaseContext);
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}