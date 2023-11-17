using Microsoft.AspNetCore.Mvc;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.BLL.Services.ShoppersService;

namespace ShoppingBuddy.API.Controllers
{
    [ApiController]
    [Route("api/v1/shoppers")]
    public class ShoppersController : ControllerBase
    {
        private readonly IShoppersService _shoppersService;

        public ShoppersController(IShoppersService shoppersService)
        {
            _shoppersService = shoppersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShopperResponseDto>>> GetAll()
        {
            var allShoppers = await _shoppersService.GetAllShoppers();
            return Ok(allShoppers);
        }
    }
}