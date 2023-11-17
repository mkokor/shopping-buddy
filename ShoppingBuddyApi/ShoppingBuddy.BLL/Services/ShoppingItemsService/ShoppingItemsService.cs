using AutoMapper;
using ShoppingBuddy.BLL.DTOs.ShoppingItem;
using ShoppingBuddy.DAL.Repositories.UnitOfWork;

namespace ShoppingBuddy.BLL.Services.ShoppingItemsService
{
    public class ShoppingItemsService : IShoppingItemsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShoppingItemsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ShoppingItemResponseDto>> GetAllShoppingItems()
        {
            var allShoppingItems = await _unitOfWork.ShoppingItemRepository.GetAll();
            return _mapper.Map<List<ShoppingItemResponseDto>>(allShoppingItems);
        }
    }
}