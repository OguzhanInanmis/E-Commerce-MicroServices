using E_Commerce.Basket.Dtos;
using E_Commerce.Basket.Services;
using E_Commerce.Basket.Services.LoginServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService basketService;
        private readonly ILoginService loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            this.basketService = basketService;
            this.loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasketDetail()
        {
            var user = User.Claims;
            var values = await basketService.GetBasket(loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = loginService.GetUserId;
            await basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(BasketTotalDto basketTotalDto)
        {
            await basketService.DeleteBasket(loginService.GetUserId);
            return Ok("Sepetteki değişiklikler kaydedildi.");
        }
    }
}
