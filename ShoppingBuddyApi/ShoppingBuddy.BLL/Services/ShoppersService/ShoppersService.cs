using AutoMapper;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.BLL.Utilities.ShoppersUtility;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Services.ShoppersService
{
    public class ShoppersService : IShoppersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppersService(IUnitOfWork uniOfWork, IMapper mapper)
        {
            _unitOfWork = uniOfWork;
            _mapper = mapper;
        }

        public async Task<List<ShopperResponseDto>> GetAllShoppers()
        {
            var allShoppers = await _unitOfWork.ShopperRepository.GetAll();
            return await ShoppersUtility.ConfigureShoppingLists(allShoppers, _unitOfWork, _mapper);
        }
    }
}