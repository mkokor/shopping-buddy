using Microsoft.AspNetCore.Mvc;
using ShoppingBuddy.BLL.Services.ShoppersService;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.API.Controllers
{
    [ApiController]
    [Route("api/shoppers")]
    public class ShoppersController : ControllerBase
    {
        private readonly IShoppersService _shoppersService;

        public ShoppersController(IShoppersService shoppersService)
        {
            _shoppersService = shoppersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shopper>>> GetAll() {
            var allShoppers = await _shoppersService.GetAllShoppers();
            return Ok(allShoppers);
        }
    }
}