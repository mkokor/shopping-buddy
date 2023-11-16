using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Services.ShoppersService
{
    public class ShoppersService : IShoppersService
    {
        private readonly IUnitOfWork _uniOfWork;

        public ShoppersService(IUnitOfWork uniOfWork)
        {
            _uniOfWork = uniOfWork;
        }

        public async Task<List<Shopper>> GetAllShoppers()
        {
            return await _uniOfWork.ShopperRepository.GetAllShoppers();
        }
    }
}