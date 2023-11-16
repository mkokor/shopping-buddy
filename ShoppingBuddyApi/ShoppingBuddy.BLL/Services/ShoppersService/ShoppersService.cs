using AutoMapper;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.DAL.Entities;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Services.ShoppersService
{
    public class ShoppersService : IShoppersService
    {
        private readonly IUnitOfWork _uniOfWork;
        private readonly IMapper _mapper;

        public ShoppersService(IUnitOfWork uniOfWork, IMapper mapper)
        {
            _uniOfWork = uniOfWork;
            _mapper = mapper;
        }

        public async Task<List<ShopperResponseDto>> GetAllShoppers()
        {
            var allShoppers = await _uniOfWork.ShopperRepository.GetAllShoppers();
            return _mapper.Map<List<ShopperResponseDto>>(allShoppers);
        }
    }
}