using AutoMapper;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.BLL.DTOs.ShoppingItem;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shopper, ShopperResponseDto>();
            CreateMap<ShoppingItem, ShoppingItemResponseDto>();
            CreateMap<ShoppingItem, ShoppingListItemResponseDto>();
        }
    }
}