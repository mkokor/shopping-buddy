using Microsoft.AspNetCore.Mvc;
using ShoppingBuddy.BLL.DTOs.ShoppingItem;
using ShoppingBuddy.BLL.Services.ShoppingItemsService;

namespace ShoppingBuddy.API.Controllers
{
    [ApiController]
    [Route("api/v1/shopping-items")]
    public class ShoppingItemsController : ControllerBase
    {
        private readonly IShoppingItemsService _shoppingItemsService;

        public ShoppingItemsController(IShoppingItemsService shoppingItemsService)
        {
            _shoppingItemsService = shoppingItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingItemResponseDto>>> GetAll()
        {
            var allShoppingItems = await _shoppingItemsService.GetAllShoppingItems();
            return Ok(allShoppingItems);
        }
    }
}