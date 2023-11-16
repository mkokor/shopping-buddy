using Microsoft.AspNetCore.Mvc;
using ShoppingBuddy.BLL.Services.ShoppingItemsService;
using ShoppingBuddy.DAL.Entities;

namespace ShoppingBuddy.API.Controllers
{
    [ApiController]
    [Route("api/shopping-items")]
    public class ShoppingItemsController : ControllerBase
    {
        private readonly IShoppingItemsService _shoppingItemsService;

        public ShoppingItemsController(IShoppingItemsService shoppingItemsService)
        {
            _shoppingItemsService = shoppingItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShoppingItem>>> GetAll()
        {
            var allShoppingItems = await _shoppingItemsService.GetAllShoppingItems();
            return Ok(allShoppingItems);
        }
    }
}