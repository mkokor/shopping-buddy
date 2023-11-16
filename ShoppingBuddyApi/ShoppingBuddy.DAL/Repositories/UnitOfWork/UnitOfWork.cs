using ShoppingBuddy.DAL.Repositories.ShopperRepository;

namespace ShoppingBuddy.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IShopperRepository ShopperRepository { get; init; }

        public UnitOfWork(DatabaseContext databaseContext)
        {
            ShopperRepository = new ShopperRepository.ShopperRepository(databaseContext);
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}