using ShoppingBuddy.DAL.Repositories.ShopperRepository;
using ShoppingBuddy.DAL.Repositories.ShoppingItemRepository;
using ShoppingBuddy.DAL.Repositories.ShoppingListRepository;

namespace ShoppingBuddy.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public IShopperRepository ShopperRepository { get; init; }
        public IShoppingItemRepository ShoppingItemRepository { get; init; }
        public IShoppingListItemRepository ShoppingListItemRepository { get; init; }

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            ShopperRepository = new ShopperRepository.ShopperRepository(databaseContext);
            ShoppingItemRepository = new ShoppingItemRepository.ShoppingItemRepository(databaseContext);
            ShoppingListItemRepository = new ShoppingListRepository.ShoppingListItemRepository(databaseContext);
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}