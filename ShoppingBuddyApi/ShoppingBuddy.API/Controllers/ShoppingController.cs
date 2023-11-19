using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ShoppingBuddy.BLL.Dtos.Shopper;
using ShoppingBuddy.BLL.Services.ShoppingService;

namespace ShoppingBuddy.API.Controllers
{
    [ApiController]
    [Route("api/v1/shopping")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [HttpPost]
        public async Task<ActionResult<List<ShopperResponseDto>>> AddToShoppingList([Required, FromQuery] int shopper, [Required, FromQuery] int shopping_item)
        {
            var shoppers = await _shoppingService.AddToShoppingList(shopper, shopping_item);
            return Ok(shoppers);
        }

        [HttpDelete("quantity")]
        public async Task<ActionResult<List<ShopperResponseDto>>> DecreaseQuantity([Required, FromQuery] int shopper, [Required, FromQuery] int shopping_item)
        {
            var shoppers = await _shoppingService.DecreaseQuantity(shopper, shopping_item);
            return Ok(shoppers);
        }
    }
}